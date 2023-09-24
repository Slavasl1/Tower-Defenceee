using Entitas;

namespace _GameLogic_.Common
{
    [Game]
    public sealed class DetectionAreaTriggerComponent : IComponent
    {
        public int targetHashcode;
    }
}