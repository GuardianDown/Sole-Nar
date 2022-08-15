using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapGeneratorInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container.Bind<ITilemapGenerator>().To<PseudoTilemapGenerator>().AsSingle();
    }
}
