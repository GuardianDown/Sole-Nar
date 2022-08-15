using Zenject;

namespace SoleNar.Input
{
    internal sealed class ControlsInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<Controls>().FromNew().AsSingle();
    }
}
