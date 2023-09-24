using _GameLogic_.Data;
using Entitas;
using UnityEngine;

namespace _GameLogic_.Enemy
{
    public class EnemySystems : Feature
    {
        private EnemyConfig _enemyConfig;

        public EnemySystems(Contexts contexts)
        {
            _enemyConfig = Resources.Load<EnemyConfig>("Balance/EnemyConfig");
            Add(new EnemySpawnerSystem(contexts, _enemyConfig));
            Add(new EnemySpawnerRequestSystem(contexts));
            Add(new NavMeshMovingSystem(contexts));
            Add(new EnemyAttackSystem(contexts));
            Add(new EnemyDetectTargetSystem(contexts));
            Add(new EnemyDeathSystem(contexts));
            Add(new UpgradeAndAddNewEnemySystem(contexts, _enemyConfig));
            Add(new CleanupEnemyStatsSystem(contexts));
        }
    }
}