namespace _GameLogic_.Common
{
    public class GeneralGameSystems : Feature
    {
        public GeneralGameSystems(Contexts contexts)
        {
            Add(new TimerExecuteSystem(contexts));
            Add(new RemoveTimerSystem(contexts));
            Add(new DetectDeathSystem(contexts));
            Add(new AttackSystem(contexts));
            Add(new DetectionAreaSystem(contexts));
        }
    }
}