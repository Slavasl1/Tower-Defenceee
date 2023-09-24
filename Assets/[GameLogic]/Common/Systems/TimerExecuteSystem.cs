using Entitas;
using UnityEngine;

namespace _GameLogic_.Common
{
    public class TimerExecuteSystem : IExecuteSystem
    {
        private IGroup<GameEntity> _timersGroup;

        public TimerExecuteSystem(Contexts contexts)
        {
            _timersGroup = contexts.game.GetGroup(GameMatcher.TimerAmount);
        }

        public void Execute()
        {
            foreach (var timerEntity in _timersGroup)
            {
                timerEntity.ReplaceTimerAmount(timerEntity.timerAmount.value - Time.deltaTime);
            }
        }
    }
}