//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public _GameLogic_.Enemy.RewardComponent reward { get { return (_GameLogic_.Enemy.RewardComponent)GetComponent(GameComponentsLookup.Reward); } }
    public bool hasReward { get { return HasComponent(GameComponentsLookup.Reward); } }

    public void AddReward(float newValue) {
        var index = GameComponentsLookup.Reward;
        var component = (_GameLogic_.Enemy.RewardComponent)CreateComponent(index, typeof(_GameLogic_.Enemy.RewardComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceReward(float newValue) {
        var index = GameComponentsLookup.Reward;
        var component = (_GameLogic_.Enemy.RewardComponent)CreateComponent(index, typeof(_GameLogic_.Enemy.RewardComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveReward() {
        RemoveComponent(GameComponentsLookup.Reward);
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

    static Entitas.IMatcher<GameEntity> _matcherReward;

    public static Entitas.IMatcher<GameEntity> Reward {
        get {
            if (_matcherReward == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Reward);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReward = matcher;
            }

            return _matcherReward;
        }
    }
}
