using System;

namespace SoleNar.UI
{
    public interface IEnemyEventView : ITileEventView
    {
        event Action onAttack;
        event Action onStealth;
        event Action onRetreat;
        event Action onClose;

        void SetEndEventState();

        void SetStealthFailedState();
    }
}
