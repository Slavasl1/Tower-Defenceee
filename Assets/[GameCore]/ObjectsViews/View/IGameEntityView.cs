using Entitas;

namespace _GameCore_
{
    public interface IGameEntityView
    {
        public void Link(GameEntity entity);
        
        public void OnDestroyEntity(IEntity entity);
        
    }
}