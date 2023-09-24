using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Towers.Systems
{
    public class TowerAttackSystem : ReactiveSystem<GameEntity>
    {
        public TowerAttackSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DetectionAreaTrigger.Added(), GameMatcher.TimerAmount.Removed());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTimerAmount == false &&
                   entity.hasDetectionAreaTrigger;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var towerEntity in entities)
            {
                towerEntity.ReplaceAttack(towerEntity.detectionAreaTrigger.targetHashcode);
            }
        }
    }
}