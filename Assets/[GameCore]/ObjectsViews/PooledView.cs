using Entitas;

namespace _GameCore_
{
    public class PooledView : View
    {
        public override void OnDestroyEntity(IEntity entity)
        {
            base.OnDestroyEntity(entity);
        }
    }
}