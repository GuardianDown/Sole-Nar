using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerMovementInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IPlayerMovement>().To<PlayerMovement>().AsSingle();
    }
}
