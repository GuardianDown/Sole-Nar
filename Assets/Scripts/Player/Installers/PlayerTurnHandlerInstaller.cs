using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerTurnHandlerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IPlayerTurnHandler>().To<PlayerTurnHandler>().AsSingle();
    }
}
