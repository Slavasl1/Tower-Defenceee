using Entitas;
using UnityEngine;

namespace _GameLogic_.Data.Systems
{
    public class InitializeDataSystem : IInitializeSystem
    {
        private GameSettings _gameSettings;

        public InitializeDataSystem(Contexts contexts)
        {
            _gameSettings = Resources.Load<GameSettings>("Balance/GameSettings");
        }

        public void Initialize()
        {
            var data = Contexts.sharedInstance.game.CreateEntity();
            data.isGameData = true;
            data.AddSoftCurrency(0);
            data.AddWaveLevel(1);
            data.AddTimerAmount(_gameSettings.WaveDuration);
            data.AddCooldown(_gameSettings.WaveDuration);
            data.AddKillCounter(0);
        }
    }
}