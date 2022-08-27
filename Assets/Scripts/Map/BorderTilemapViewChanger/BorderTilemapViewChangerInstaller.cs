using Zenject;

namespace SoleNar.Map
{
    internal sealed class BorderTilemapViewChangerInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container
            .Bind<IBorderTilemapViewChanger>()
            .To<BorderTilemapViewChanger>()
            .AsSingle();
    }
}
