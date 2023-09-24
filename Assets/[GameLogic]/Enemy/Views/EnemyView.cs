using _GameCore_;
using UnityEngine;
using UnityEngine.AI;

namespace _GameLogic_.Enemy
{
    public class EnemyView : PooledView
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.isEnemy = true;
            entity.AddNavMeshAgent(navMeshAgent);
        }
    }
}