using UnityEditor;
using UnityEngine;

namespace _GameLogic_.Data
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig", order = 0)]
    public class EnemyConfig : ScriptableSingleton<EnemyConfig>
    {
        [field: SerializeField] public float DefaultEnemyHp { get; private set; }
        [field: SerializeField] public float DefaultEnemyDamage { get; private set; }
        [field: SerializeField] public int DefaultEnemyReward { get; private set; }
        [field: SerializeField] public float EnemyDifficultMultiplayer { get; private set; }
        [field: SerializeField] public int MaxAdditionalEnemyCount { get; private set; }
        [field: SerializeField] public float EnemySpawnDelay { get; private set; }
    }
}