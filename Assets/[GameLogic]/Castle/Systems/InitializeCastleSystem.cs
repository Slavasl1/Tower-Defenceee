using _GameLogic_.Castle.Views;
using _GameLogic_.Data;
using Entitas;
using UnityEngine;

namespace _GameLogic_.Castle.Systems
{
    public class InitializeCastleSystem : IInitializeSystem
    {
        private GameSettings _gameSettings;

        public InitializeCastleSystem(Contexts contexts)
        {
            _gameSettings = Resources.Load<GameSettings>("Balance/GameSettings");
        }

        public void Initialize()
        {
            var castleEntity = Contexts.sharedInstance.game.CreateEntity();
            UnityEngine.Object.FindObjectOfType<CastleView>().Link(castleEntity);
            castleEntity.AddHealth(_gameSettings.CastleHealth);
        }
    }
}