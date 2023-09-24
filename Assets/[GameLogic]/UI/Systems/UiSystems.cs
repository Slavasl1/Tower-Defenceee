namespace _GameLogic_.UI.Systems
{
    public class UiSystems : Feature
    {
        public UiSystems(Contexts contexts)
        {
            Add(new DefeatScreenInitializeSystem(contexts));
            Add(new DefeatScreenSystem(contexts));
        }
    }
}