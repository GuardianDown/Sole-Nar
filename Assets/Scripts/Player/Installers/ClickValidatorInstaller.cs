using Zenject;

namespace SoleNar.Player
{
    internal sealed class ClickValidatorInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IClickValidator>().To<ClickValidator>().AsSingle();
    }
}
