using System.Collections.Generic;
using _GameLogic_.Input.Views;
using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _GameLogic_.Input.Systems
{
    public class DetectClickSystem : ReactiveSystem<GameEntity>
    {
        private Camera _camera;

        public DetectClickSystem(Contexts contexts) : base(contexts.game)
        {
            _camera = Camera.main;
        }


        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Input.Added());
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInput;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                Ray ray = _camera.ScreenPointToRay(inputEntity.input.value);
                RaycastHit hit;     
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 10);
                if (Physics.Raycast(ray, out hit) &&
                    !EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.collider.TryGetComponent<IRaycasted>(out IRaycasted raycasted))
                    {
                        raycasted.RaycastedEntity.isClicked = true;
                    }
                }
            }
        }
    }
}