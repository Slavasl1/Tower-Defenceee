using _GameCore_;
using UnityEngine;

namespace _GameLogic_.Enemy
{
    public class SpawnerView : GameView
    {
        [SerializeField] private EnemyView _enemyViewPrefab;
        [SerializeField] private Transform _spawnPoint;

        public EnemyView EnemyViewPrefab => _enemyViewPrefab;

        public override void Link(GameEntity entity)
        {
            base.Link(entity);
            entity.AddSpawnPoint(_spawnPoint.position);
        }
    }
}