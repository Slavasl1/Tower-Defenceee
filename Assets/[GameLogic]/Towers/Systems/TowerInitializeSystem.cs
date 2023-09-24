using _GameLogic_.Data;
using _GameLogic_.Towers.Views;
using Entitas;

namespace _GameLogic_.Towers.Systems
{
    public class TowerInitializeSystem : IInitializeSystem
    {
        private readonly TowerConfig _towerConfig;
        private readonly GameContext _contextsGame;

        public TowerInitializeSystem(Contexts contexts, TowerConfig towerConfig)
        {
            _towerConfig = towerConfig;
            _contextsGame = contexts.game;
        }

        public void Initialize()
        {
            var towerViews = UnityEngine.Object.FindObjectsOfType<TowerView>();
            foreach (var towerView in towerViews)
            {
                var gameEntity = _contextsGame.CreateEntity();
                towerView.Link(gameEntity);
                gameEntity.AddAttackDamage(_towerConfig.DefaultTowerDamage);
                gameEntity.AddFireRate(_towerConfig.DefaultTowerFireRate);
                gameEntity.AddUpgradeCost(_towerConfig.DefaultTowerUpgradeCost);
            }
        }
    }
}