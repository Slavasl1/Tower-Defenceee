namespace _GameLogic_.Input.Systems
{
    public class InputSystems : Feature
    {
        public InputSystems(Contexts contexts)
        {
            Add(new InputExecuteSystem(contexts));
            Add(new DetectClickSystem(contexts));
        }
    }
}