using Entitas;
using UnityEngine;

namespace _GameLogic_.Enemy
{
    [Game]
    public sealed class SpawnPointComponent : IComponent
    {
        public Vector3 value;
    }
}