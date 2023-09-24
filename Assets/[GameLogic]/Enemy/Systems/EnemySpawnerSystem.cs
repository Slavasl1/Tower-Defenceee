using System.Collections.Generic;
using System.Linq;
using _GameLogic_.Data;
using DesperateDevs.Utils;
using Entitas;
using UnityEngine;

namespace _GameLogic_.Enemy
{
    public class EnemySpawnerSystem : ReactiveSystem<GameEntity>, IInitializeSystem
    {
        public static ObjectPool<EnemyView> Pool;
        private readonly GameContext _contextsGame;
        private GameEntity _spawnerEntity;
        private EnemyView _prefab;
        private EnemyConfig _enemyConfig;
        private readonly IGroup<GameEntity> _statsGroup;
        private const int PoolLenght = 20;

        public EnemySpawnerSystem(Contexts contexts, EnemyConfig enemyConfig) : base(contexts.game)
        {
            _contextsGame = contexts.game;
            _enemyConfig = enemyConfig;
            var statsEntity = _contextsGame.CreateEntity();
            var newAmount = UnityEngine.Random.Range(1, _enemyConfig.MaxAdditionalEnemyCount);
            statsEntity.AddEnemyWaveStats(_enemyConfig.DefaultEnemyHp, _enemyConfig.DefaultEnemyDamage,
                _enemyConfig.DefaultEnemyReward);
            statsEntity.AddWaveLevel(1);
            statsEntity.AddEnemyAmount(newAmount);
            _statsGroup = _contextsGame.GetGroup(GameMatcher.EnemyWaveStats);
        }

        public void Initialize()
        {
            _spawnerEntity = _contextsGame.CreateEntity();
            _spawnerEntity.isEnemySpawner = true;
            _spawnerEntity.AddCooldown(_enemyConfig.EnemySpawnDelay);
            _spawnerEntity.AddTimerAmount(_spawnerEntity.cooldown.value);
            var spawnerView = UnityEngine.Object.FindObjectOfType<SpawnerView>();
            spawnerView.Link(_spawnerEntity);
            _prefab = spawnerView.EnemyViewPrefab;
            Pool = new ObjectPool<EnemyView>(InstantiateEnemy, UnlinkEnemy);
            for (int i = 0; i < PoolLenght; i++)
            {
                Pool.Push(InstantiateEnemy());
            }
        }

        private void UnlinkEnemy(EnemyView obj)
        {
            obj.transform.gameObject.SetActive(false);
            var objGameEntity = obj.GameEntity;
            if (objGameEntity == null) return;
            objGameEntity.Destroy();
            obj.GameEntity = null;
        }

        private EnemyView InstantiateEnemy()
        {
            var enemyView =
                UnityEngine.Object.Instantiate(_prefab, _spawnerEntity.spawnPoint.value, Quaternion.identity);
            _prefab.transform.position = _spawnerEntity.transform.value.position;
            return enemyView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.SpawnRequest.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return _statsGroup.count > 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var statsEntities = _statsGroup.GetEntities();
            var min = statsEntities.Min(x => x.waveLevel.value);
            var statsEntity = statsEntities.FirstOrDefault(x => x.waveLevel.value == min);
#if UNITY_EDITOR
            Debug.Assert(statsEntity != null, "statsEntity != null");
#endif
            var enemyView = Pool.Get();
            enemyView.transform.gameObject.SetActive(true);
            statsEntity.ReplaceEnemyAmount(statsEntity.enemyAmount.value - 1);
            var enemyEntity = _contextsGame.CreateEntity();
            enemyView.Link(enemyEntity);
            enemyEntity.ReplaceAttackDamage(statsEntity.enemyWaveStats.damage);
            enemyEntity.ReplaceHealth(statsEntity.enemyWaveStats.hp);
            enemyEntity.ReplaceReward(statsEntity.enemyWaveStats.reward);
            enemyEntity.ReplaceNMAgentDestination(_contextsGame.castleEntity.transform.value.position);
            SetDefaultPosition();
            return;

            void SetDefaultPosition()
            {
                enemyEntity.transform.value.position = _spawnerEntity.spawnPoint.value;
                enemyEntity.navMeshAgent.value.nextPosition = _spawnerEntity.spawnPoint.value;
                enemyEntity.navMeshAgent.value.updatePosition = true;
            }
        }
    }
}