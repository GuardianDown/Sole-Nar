using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerFuelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerResource<int>>().To<PlayerFuel>().AsSingle();
            Container.Bind<IPlayerResource<int>>().To<PlayerHealth>().AsSingle();
        }
    }
}
