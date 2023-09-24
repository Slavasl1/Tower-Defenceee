using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _GameLogic_.Data.Components
{
    [Game, Event(EventTarget.Any)]
    public sealed class SoftCurrencyComponent : IComponent
    {
        public float value;
    }
}