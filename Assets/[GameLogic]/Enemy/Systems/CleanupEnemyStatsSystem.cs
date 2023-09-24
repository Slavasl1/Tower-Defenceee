using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class CleanupEnemyStatsSystem : ReactiveSystem<GameEntity>
    {
        public CleanupEnemyStatsSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.EnemyAmount);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasEnemyWaveStats && entity.enemyAmount.value <= 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.Destroy();
            }
        }
    }
}