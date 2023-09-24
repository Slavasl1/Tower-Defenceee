using System.Collections.Generic;
using System.Linq;
using _GameLogic_.Data;
using Entitas;
using Random = UnityEngine.Random;

namespace _GameLogic_.Enemy
{
    public class UpgradeAndAddNewEnemySystem : ReactiveSystem<GameEntity>
    {
        private readonly EnemyConfig _enemyConfig;
        private GameContext _contextsGame;
        private IGroup<GameEntity> _enemyStatsGroup;

        public UpgradeAndAddNewEnemySystem(Contexts contexts, EnemyConfig enemyConfig) : base(contexts.game)
        {
            _enemyConfig = enemyConfig;
            _contextsGame = contexts.game;
            _enemyStatsGroup =
                contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.EnemyWaveStats, GameMatcher.WaveLevel));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.WaveLevel);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameData;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            var dataEntity = _contextsGame.gameDataEntity;
            var currentWaveLevel = dataEntity.waveLevel.value;
            var newEnemyCount = UnityEngine.Random.Range(currentWaveLevel,
                currentWaveLevel + _enemyConfig.MaxAdditionalEnemyCount);
            var lastEnemyWave = _enemyStatsGroup.GetEntities()
                .FirstOrDefault(x => x.waveLevel.value == currentWaveLevel);
            float newHp;
            float newDamage;
            float newReward;

            if (lastEnemyWave == null)
            {
                newHp = _enemyConfig.DefaultEnemyHp;
                newDamage = _enemyConfig.DefaultEnemyDamage;
                newReward = _enemyConfig.DefaultEnemyReward;
            }
            else
            {
                newHp = UpgradeValue(lastEnemyWave.enemyWaveStats.hp);
                newDamage = UpgradeValue(lastEnemyWave.enemyWaveStats.damage);
                newReward = UpgradeValue(lastEnemyWave.enemyWaveStats.reward);
            }

            var entity = _contextsGame.CreateEntity();
            entity.AddEnemyWaveStats(newHp, newDamage, newReward);
            entity.AddWaveLevel(currentWaveLevel);
            entity.AddEnemyAmount(newEnemyCount);
            return;

            float UpgradeValue(float defaultValue) =>
                defaultValue + Random.Range(0, _enemyConfig.EnemyDifficultMultiplayer);
        }
    }
}