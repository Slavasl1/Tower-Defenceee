using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace _GameCore_.Components
{
    [Game]
    public sealed class HashCodeComponent : IComponent
    {
        [PrimaryEntityIndex] public int value;
    }
}