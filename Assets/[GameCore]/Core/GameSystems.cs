using _GameLogic_.Castle.Systems;
using _GameLogic_.Common;
using _GameLogic_.Data.Systems;
using _GameLogic_.Enemy;
using _GameLogic_.Input.Systems;
using _GameLogic_.Towers.Systems;
using _GameLogic_.UI.Systems;

namespace _GameCore_.Core
{
    public class GameSystems : Feature
    {
        public GameSystems(Contexts contexts)
        {
            Add(new InputSystems(contexts));
            Add(new DataSystems(contexts));
            Add(new GeneralGameSystems(contexts));
            Add(new EnemySystems(contexts));
            Add(new CastleSystems(contexts));
            Add(new TowerSystems(contexts));
            Add(new UiSystems(contexts));
            
            Add(new GameCleanupSystems(contexts));
            Add(new GameEventSystems(contexts));
        }
    }
}