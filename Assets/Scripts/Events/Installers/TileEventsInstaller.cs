using Zenject;

namespace SoleNar.Events
{
    internal class TileEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITileEvent>().To<InspectTileEvent>().AsSingle();
            Container.Bind<ITileEvent>().To<EnemyTileEvent>().AsSingle();
        }
    }
}
