using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class EnemyAttackSystem : ReactiveSystem<GameEntity>
    {
        public EnemyAttackSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Attack.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy;
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