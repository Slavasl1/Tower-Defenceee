using Entitas;

namespace _GameLogic_.Common.Components
{
    [Game]
    public sealed class NavMeshAgentComponent : IComponent
    {
        public UnityEngine.AI.NavMeshAgent value;
    }
}