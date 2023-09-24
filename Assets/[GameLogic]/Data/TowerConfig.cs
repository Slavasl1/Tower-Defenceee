using UnityEngine;

namespace _GameLogic_.Data
{
    [CreateAssetMenu(fileName = "TowerConfig", menuName = "Configs/TowerConfig", order = 0)]
    public class TowerConfig : ScriptableObject
    {
        [field: SerializeField] public float DefaultTowerDamage { get; private set; }
        [field: SerializeField] public float DefaultTowerFireRate { get; private set; }
        [field: SerializeField] public float UpgradeCostMultiplayer { get; private set; }
        [field: SerializeField] public float UpgradeStatsMultiplayer { get; private set; }
        [field: SerializeField] public float DefaultTowerUpgradeCost { get; set; }
    }
}