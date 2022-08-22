using Zenject;

namespace SoleNar.Events
{
    internal sealed class TileEventCallerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<ITileEventCaller>().To<TileEventCaller>().AsSingle();
    }
}
