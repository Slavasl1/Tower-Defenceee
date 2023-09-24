using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace _GameLogic_.Data.Systems
{
    public class LevelRestartSystem : ReactiveSystem<GameEntity>
    {
        private GameContext _contextsGame;
        private IGroup<GameEntity> _enemyGroup;
        private GameSettings _gameSettings;

        public LevelRestartSystem(Contexts contexts) : base(contexts.game)
        {
            _gameSettings = Resources.Load<GameSettings>("Balance/GameSettings");
            _contextsGame = contexts.game;
            _enemyGroup = contexts.game.GetGroup(GameMatcher.Enemy);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.RestartRequest);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            _contextsGame.uiDefeatScreenEntity.ReplaceEnabled(false);
            foreach (var enemy in _enemyGroup)
            {
                enemy.isDead = true;
            }

            _contextsGame.castleEntity.ReplaceHealth(_gameSettings.CastleHealth);
            _contextsGame.castleEntity.isDead = false;
            _contextsGame.gameDataEntity.ReplaceWaveLevel(1);
            _contextsGame.gameDataEntity.ReplaceKillCounter(0);
            _contextsGame.gameDataEntity.ReplaceSoftCurrency(0);
        }
    }
}