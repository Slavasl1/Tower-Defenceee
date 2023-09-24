using System;
using Entitas;
using UnityEngine;

namespace _GameLogic_.Common
{
    public class DetectionAreaSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _enemyGroup;
        private readonly IGroup<GameEntity> _detectionAreaGroup;

        public bool IsInFlatArea(in Vector3 source, in Bounds area)
        {
            return source.x > area.min.x && source.x < area.max.x &&
                   source.z > area.min.z && source.z < area.max.z;
        }

        public DetectionAreaSystem(Contexts contexts)
        {
            _enemyGroup = contexts.game.GetGroup(GameMatcher.Enemy);
            _detectionAreaGroup = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.DetectionArea));
        }

        public void Execute()
        {
            foreach (var detectionEntity in _detectionAreaGroup.GetEntities())
            {
                foreach (var enemy in _enemyGroup.GetEntities())
                {
                    if (IsInFlatArea(enemy.transform.value.position, detectionEntity.detectionArea.value))
                    {
                        if (!detectionEntity.hasDetectionAreaTrigger)
                        {
                            detectionEntity.AddDetectionAreaTrigger(enemy.hashCode.value);
                            break;
                        }
                    }
                    else
                    {
                        if (detectionEntity.hasDetectionAreaTrigger) detectionEntity.RemoveDetectionAreaTrigger();
                    }
                }
            }
        }
    }
}