using Entitas;

namespace _GameCore_.Components
{
    [Game]
    public sealed class TransformComponent : IComponent
    {
        public UnityEngine.Transform value;
    }
}