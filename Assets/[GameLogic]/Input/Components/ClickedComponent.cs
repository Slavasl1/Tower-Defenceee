using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _GameLogic_.Input.Components
{
    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public sealed class ClickedComponent : IComponent
    {
    }
}