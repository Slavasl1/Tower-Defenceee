using _GameLogic_.UI.Views;
using Entitas;

namespace _GameLogic_.UI.Systems
{
    public class DefeatScreenInitializeSystem : IInitializeSystem
    {
        public DefeatScreenInitializeSystem(Contexts contexts)
        {
        }

        public void Initialize()
        {
            UnityEngine.Object.FindObjectOfType<DefeatScreen>(true).Link(Contexts.sharedInstance.game.CreateEntity());
        }
    }
}