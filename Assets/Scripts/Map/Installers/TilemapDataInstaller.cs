using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapDataInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<ITilemapData>().To<TilemapData>().AsSingle();
    }
}
