using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class EnemySpawnerRequestSystem : ReactiveSystem<GameEntity>
    {
        private readonly Contexts _contexts;

        public EnemySpawnerRequestSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TimerAmount.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemySpawner && !entity.hasTimerAmount;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var enemySpawner in entities)
            {
                _contexts.game.CreateEntity().isSpawnRequest = true;
                enemySpawner.ReplaceTimerAmount(enemySpawner.cooldown.value);
            }
        }
    }
}