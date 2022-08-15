using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerDeathInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IPlayerDeath>().To<PlayerDeath>().AsSingle();
    }
}
