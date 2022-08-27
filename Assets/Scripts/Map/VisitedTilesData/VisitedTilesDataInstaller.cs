using Zenject;

namespace SoleNar.Map
{
    internal sealed class VisitedTilesDataInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container
            .Bind<IVisitedTilesData>()
            .To<VisitedTilesData>()
            .AsSingle();
    }
}
