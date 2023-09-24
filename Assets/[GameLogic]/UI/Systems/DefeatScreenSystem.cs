using System.Collections.Generic;
using Entitas;

namespace _GameLogic_.UI.Systems
{
    public class DefeatScreenSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _contextsGame;

        public DefeatScreenSystem(Contexts contexts) : base(contexts.game)
        {
            _contextsGame = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Defeat);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _contextsGame.uiDefeatScreenEntity.ReplaceEnabled(true);
        }
    }
}