using SoleNar.UI;
using Zenject;

namespace SoleNar.Events
{
    public class BattleEvent
    {
        private readonly BattleView _battleView;

        [Inject]
        public BattleEvent(BattleView battleView)
        {
            _battleView = battleView;
        }
    }
}
