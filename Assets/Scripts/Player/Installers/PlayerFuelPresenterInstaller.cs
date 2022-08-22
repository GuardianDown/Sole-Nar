using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerFuelPresenterInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<PlayerFuelPresenter>().AsSingle();
    }
}
