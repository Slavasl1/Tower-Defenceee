using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Data.Systems
{
    public class DefeatDetectSystem : ReactiveSystem<GameEntity>
    {
        public DefeatDetectSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Dead);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isCastle;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            Contexts.sharedInstance.game.CreateEntity().isDefeat = true;
        }
    }
}