using UnityEngine;

namespace _GameLogic_.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Configs/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField] public float CastleHealth { get; private set; }
        [field: SerializeField] public float WaveDuration { get; private set; }
        
        
    }
}