using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace _GameCore_
{
    public class View : MonoBehaviour, IGameEntityView
    {
        public GameEntity GameEntity;

        public virtual void Link(GameEntity entity)
        {
            GameEntity = entity;
            gameObject.Link(entity);
            entity.AddTransform(transform);
            entity.AddHashCode(GetHashCode());
            entity.OnDestroyEntity += OnDestroyEntity;
        }

        public virtual void OnDestroyEntity(IEntity entity)
        {
            entity.OnDestroyEntity -= OnDestroyEntity;
            if (GameEntity == null) return;
            gameObject.Unlink();
            GameEntity = null;
        }
        

        private void OnDestroy()
        {
            if (gameObject.GetEntityLink() == null) return;
            if (gameObject.GetEntityLink().entity == null) return;
            GameEntity?.Destroy();
        }
    }
}