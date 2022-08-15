using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapClickHandlerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<ITilemapClickHandler>().To<TilemapClickHandler>().AsSingle();
    }
}