using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapCursorPositionInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container
            .Bind<ITilemapCursorPosition>()
            .To<TilemapCursorPosition>()
            .AsSingle();

    }
}
