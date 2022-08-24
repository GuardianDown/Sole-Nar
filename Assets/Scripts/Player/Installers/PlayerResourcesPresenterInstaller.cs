using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerResourcesPresenterInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container
            .Bind<IPlayerResourcesPresenter<int>>()
            .To<PlayerResourcesPresenter>()
            .AsSingle();
    }
}
