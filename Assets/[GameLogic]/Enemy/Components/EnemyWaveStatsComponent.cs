using Entitas;

namespace _GameLogic_.Enemy
{
    [Game]
    public sealed class EnemyWaveStatsComponent : IComponent
    {
        public float hp;
        public float damage;
        public float reward;
    }
}