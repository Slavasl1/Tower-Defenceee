using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class NavMeshMovingSystem : ReactiveSystem<GameEntity>
    {
        public NavMeshMovingSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.NMAgentDestination.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var movableEntity in entities)
            {
                movableEntity.navMeshAgent.value.destination = movableEntity.nMAgentDestination.value;
            }
        }
    }
}