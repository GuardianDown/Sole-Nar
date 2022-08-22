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

        public override void AddValue(int value)
        {
            base.AddValue(value);
            if (_currentValue <= 0)
                onResourceOver?.Invoke();
        }
    }
}
