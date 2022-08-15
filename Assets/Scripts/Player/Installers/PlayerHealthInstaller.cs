using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerHealthInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<ICriticalPlayerResource<int>>().WithId(PlayerResourceIDs.HealthID).To<PlayerHealth>().AsSingle();
    }
}
