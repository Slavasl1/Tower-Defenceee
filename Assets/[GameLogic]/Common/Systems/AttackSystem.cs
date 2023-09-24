using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Common
{
    public class AttackSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _contextsGame;

        public AttackSystem(Contexts contexts) : base(contexts.game)
        {
            _contextsGame = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Attack.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasTimerAmount == false
                && entity.hasAttackDamage;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var targetEntity = _contextsGame.GetEntityWithHashCode(gameEntity.attack.targetHashcode);
                if(targetEntity == null) continue;
                targetEntity.ReplaceHealth(targetEntity.health.value - gameEntity.attackDamage.value);
                if(gameEntity.hasFireRate) gameEntity.ReplaceTimerAmount(1f/gameEntity.fireRate.value);
                gameEntity.RemoveAttack();
            }
        }
    }
}