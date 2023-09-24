using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Common
{
    public class DetectDeathSystem : ReactiveSystem<GameEntity>
    {
        public DetectDeathSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Health);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.health.value <= 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.isDead = true;
            }
        }
    }
}