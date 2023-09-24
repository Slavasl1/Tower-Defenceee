using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _GameLogic_.Enemy
{
    [Game, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class SpawnRequestComponent : IComponent
    {
        
    }
}