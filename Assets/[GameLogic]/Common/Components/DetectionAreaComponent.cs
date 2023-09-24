using Entitas;
using UnityEngine;

namespace _GameLogic_.Common
{
    [Game]
    public sealed class DetectionAreaComponent : IComponent
    {
        public Bounds value;
    }
}