using System;
using Entitas;
using UnityEngine;

public sealed class InputExecuteSystem : IExecuteSystem
{
    private readonly GameContext _gameContext;
    private readonly Camera _camera;

    public InputExecuteSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _camera = Camera.main;
    }

    public void Execute()
    {
        EmitInput();
    }

    void EmitInput()
    {
        var input = Input.GetMouseButtonDown(0);
        if (!input) return;
        
        var mouseWorldPos = (Input.mousePosition);
        var e = _gameContext.CreateEntity();
        e.AddInput(new Vector2Int(
            (int)Math.Round(mouseWorldPos.x),
            (int)Math.Round(mouseWorldPos.y)
        ));
    }
}
