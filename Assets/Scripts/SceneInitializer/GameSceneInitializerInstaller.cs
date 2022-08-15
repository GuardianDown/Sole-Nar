using Zenject;

namespace SoleNar.SceneInitializer
{
    internal sealed class GameSceneInitializerInstaller : MonoInstaller
    {
        public override void InstallBindings() =>
            Container.Bind<ISceneInitializer>().To<GameSceneInitializer>().AsSingle();
    }
}
