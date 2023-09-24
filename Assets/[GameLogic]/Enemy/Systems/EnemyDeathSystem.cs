using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class EnemyDeathSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _contextsGame;

        public EnemyDeathSystem(Contexts contexts) : base(contexts.game)
        {
            _contextsGame = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                _contextsGame.CreateEntity().AddReward(entity.reward.value);
                _contextsGame.gameDataEntity.ReplaceKillCounter(_contextsGame.gameDataEntity.killCounter.value + 1);
                var gameObject = entity.transform.value.gameObject;
                EnemySpawnerSystem.Pool.Push(gameObject.GetComponent<EnemyView>());
            }
        }
    }
}