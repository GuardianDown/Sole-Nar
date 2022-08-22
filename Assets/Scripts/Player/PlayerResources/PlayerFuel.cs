using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerFuel : CriticalPlayerResourceInt
    {
        private const string Id = "Fuel";

        public override string ID => Id;

        [Inject]
        public PlayerFuel(IPlayerData playerData) : base(playerData)
        {

        }

        protected override int GetStartValue() => _playerData.StartFuelValue;

        protected override int GetMaxValue() => _playerData.MaxFuelValue;
    }
}
