using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerHealth : CriticalPlayerResourceInt
    {
        [Inject]
        public PlayerHealth(IPlayerData playerData) : base(playerData)
        {
            
        }

        protected override int GetStartValue() => _playerData.StartHealthValue;

        protected override int GetMaxValue() => _playerData.MaxHealthValue;
    }
}
