using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _GameLogic_.Common
{
    [Game]
    public sealed class AttackComponent : IComponent
    {
        public int targetHashcode;
    }
}