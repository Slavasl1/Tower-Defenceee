using _GameCore_;
using _GameLogic_.Input.Views;
using UnityEngine;

namespace _GameLogic_.Towers.Views
{
    public class TowerView : GameView, IRaycasted
    {
        [SerializeField] private DetectionArea detectionArea;
        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.isTower = true;
            entity.AddTowerLevel(1);
            entity.AddDetectionArea(detectionArea.Bounds);
            
        }

        public GameEntity RaycastedEntity => GameEntity;
    }
}