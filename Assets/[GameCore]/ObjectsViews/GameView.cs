using Entitas;

namespace _GameCore_
{
    public class GameView : View
    {
        public override void OnDestroyEntity(IEntity entity)
        {
            base.OnDestroyEntity(entity);
            Destroy(gameObject);
        }
    }
}