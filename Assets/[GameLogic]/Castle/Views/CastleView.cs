using _GameCore_;
using UnityEngine;

namespace _GameLogic_.Castle.Views
{
    public class CastleView : GameView
    {
        [SerializeField] private DetectionArea detectionArea;
        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.isCastle = true;
            entity.AddDetectionArea(detectionArea.Bounds);
        }
    }
}