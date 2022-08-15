using System;
using Zenject;

namespace SoleNar.Player
{
    public abstract class CriticalPlayerResourceInt : PlayerResourceInt, ICriticalPlayerResource<int>
    {
        public event Action onResourceOver;

        [Inject]
        public CriticalPlayerResourceInt(IPlayerData playerData) : base(playerData)
        {

        }

        public override void Decrease(int value)
        {
            base.Decrease(value);
            if (_currentValue <= 0)
                onResourceOver?.Invoke();
        }
    }
}
