using _GameLogic_.Data;
using UnityEngine;

namespace _GameLogic_.Towers.Systems
{
    public class TowerSystems : Feature
    {
        private TowerConfig _towerConfig;

        public TowerSystems(Contexts contexts)
        {
            _towerConfig = Resources.Load<TowerConfig>("Balance/TowerConfig");
            Add(new TowerInitializeSystem(contexts, _towerConfig));
            Add(new TowerAttackSystem(contexts));
            Add(new TowerUpgradeSystem(contexts, _towerConfig));
        }
    }
}