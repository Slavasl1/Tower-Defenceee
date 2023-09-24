using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Enemy
{
    public class EnemyDetectTargetSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _contextsGame;

        public EnemyDetectTargetSystem(Contexts contexts) : base(contexts.game)
        {
            _contextsGame = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.DetectionAreaTrigger);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isCastle;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var castleEntity in entities)
            {
                var enemy = _contextsGame.GetEntityWithHashCode(castleEntity.detectionAreaTrigger.targetHashcode);
                enemy?.AddAttack(castleEntity.hashCode.value);
            }
        }
    }
}