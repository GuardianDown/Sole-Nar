using Zenject;

namespace SoleNar.Events
{
    internal sealed class DiceRollInstaller : MonoInstaller
    {
        public override void InstallBindings() => 
            Container.Bind<IDiceRoll>().To<DiceRoll>().AsSingle();
    }
}
