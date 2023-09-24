using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Common
{
    public class RemoveTimerSystem : ReactiveSystem<GameEntity>
    {
        public RemoveTimerSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TimerAmount);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.timerAmount.value <= 0;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.RemoveTimerAmount();
            }
        }
    }
}