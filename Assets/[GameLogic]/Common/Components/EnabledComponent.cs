using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _GameLogic_.Common
{
    [Game, Event(EventTarget.Self)]
    public sealed class EnabledComponent : IComponent
    {
        public bool value;
    }
}