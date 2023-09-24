using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique, Cleanup(CleanupMode.DestroyEntity)]
public sealed class InputComponent : IComponent
{
    public Vector2 value;
}
