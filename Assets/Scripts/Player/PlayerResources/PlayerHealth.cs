using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerHealth : CriticalPlayerResourceInt
    {
        private const string Id = "Health";

        public override string ID => Id;

        [Inject]
        public PlayerHealth(IPlayerData playerData) : base(playerData)
        {
            
        }

        protected override int GetStartValue() => _playerData.StartHealthValue;

        protected override int GetMaxValue() => _playerData.MaxHealthValue;
    }
}
