using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Data.Systems
{
    public class WaveLevelSystem : ReactiveSystem<GameEntity>
    {
        public WaveLevelSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.TimerAmount.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameData && !entity.hasTimerAmount;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ReplaceWaveLevel(entity.waveLevel.value + 1);
                entity.ReplaceTimerAmount(entity.cooldown.value);
            }
        }
    }
}