//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _GameLogic_.Common.Components.MovementSpeedComponent movementSpeed { get { return (_GameLogic_.Common.Components.MovementSpeedComponent)GetComponent(GameComponentsLookup.MovementSpeed); } }
    public bool hasMovementSpeed { get { return HasComponent(GameComponentsLookup.MovementSpeed); } }

    public void AddMovementSpeed(float newValue) {
        var index = GameComponentsLookup.MovementSpeed;
        var component = (_GameLogic_.Common.Components.MovementSpeedComponent)CreateComponent(index, typeof(_GameLogic_.Common.Components.MovementSpeedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceMovementSpeed(float newValue) {
        var index = GameComponentsLookup.MovementSpeed;
        var component = (_GameLogic_.Common.Components.MovementSpeedComponent)CreateComponent(index, typeof(_GameLogic_.Common.Components.MovementSpeedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveMovementSpeed() {
        RemoveComponent(GameComponentsLookup.MovementSpeed);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMovementSpeed;

    public static Entitas.IMatcher<GameEntity> MovementSpeed {
        get {
            if (_matcherMovementSpeed == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MovementSpeed);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovementSpeed = matcher;
            }

            return _matcherMovementSpeed;
        }
    }
}