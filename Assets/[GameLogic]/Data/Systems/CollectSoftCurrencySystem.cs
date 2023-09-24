using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.Data.Systems
{
    public class CollectSoftCurrencySystem : ReactiveSystem<GameEntity>
    {
        private GameContext _contextsGame;

        public CollectSoftCurrencySystem(Contexts contexts) : base(contexts.game)
        {
            _contextsGame = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Reward.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isEnemy == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                _contextsGame.gameDataEntity.ReplaceSoftCurrency(_contextsGame.gameDataEntity.softCurrency.value + entity.reward.value);
                entity.Destroy();
            }
        }
    }
}