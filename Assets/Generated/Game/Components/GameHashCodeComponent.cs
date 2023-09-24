//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _GameCore_.Components.HashCodeComponent hashCode { get { return (_GameCore_.Components.HashCodeComponent)GetComponent(GameComponentsLookup.HashCode); } }
    public bool hasHashCode { get { return HasComponent(GameComponentsLookup.HashCode); } }

    public void AddHashCode(int newValue) {
        var index = GameComponentsLookup.HashCode;
        var component = (_GameCore_.Components.HashCodeComponent)CreateComponent(index, typeof(_GameCore_.Components.HashCodeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceHashCode(int newValue) {
        var index = GameComponentsLookup.HashCode;
        var component = (_GameCore_.Components.HashCodeComponent)CreateComponent(index, typeof(_GameCore_.Components.HashCodeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveHashCode() {
        RemoveComponent(GameComponentsLookup.HashCode);
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

    static Entitas.IMatcher<GameEntity> _matcherHashCode;

    public static Entitas.IMatcher<GameEntity> HashCode {
        get {
            if (_matcherHashCode == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HashCode);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHashCode = matcher;
            }

            return _matcherHashCode;
        }
    }
}
