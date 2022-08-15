using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerFuelInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container.Bind<ICriticalPlayerResource<int>>().WithId(PlayerResourceIDs.FuelID).To<PlayerFuel>().AsSingle();
    }
}
