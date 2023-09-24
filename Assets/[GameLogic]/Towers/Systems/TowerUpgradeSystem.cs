using System;
using System.Collections.Generic;
using _GameLogic_.Data;
using Entitas;

namespace _GameLogic_.Towers.Systems
{
    public class TowerUpgradeSystem : ReactiveSystem<GameEntity>
    {
        private readonly TowerConfig _towerConfig;
        private GameContext _contextsGame;

        public TowerUpgradeSystem(Contexts contexts, TowerConfig towerConfig) : base(contexts.game)
        {
            _towerConfig = towerConfig;
            _contextsGame = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Clicked);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTower && _contextsGame.gameDataEntity.softCurrency.value >= entity.upgradeCost.value;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var towerEntity in entities)
            {
                _contextsGame.gameDataEntity.ReplaceSoftCurrency(_contextsGame.gameDataEntity.softCurrency.value - towerEntity.upgradeCost.value);
                towerEntity.ReplaceAttackDamage(towerEntity.attackDamage.value*_towerConfig.UpgradeStatsMultiplayer);
                towerEntity.ReplaceFireRate(towerEntity.fireRate.value*_towerConfig.UpgradeStatsMultiplayer);
                towerEntity.ReplaceTowerLevel(towerEntity.towerLevel.value ++);
                towerEntity.ReplaceUpgradeCost(towerEntity.upgradeCost.value * _towerConfig.UpgradeCostMultiplayer);
            }
        }
    }
}