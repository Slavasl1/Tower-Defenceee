using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _GameLogic_.Data.Components
{
    [Game, Cleanup(CleanupMode.DestroyEntity)]
    public sealed class RestartRequestComponent : IComponent
    {
        
    }
}