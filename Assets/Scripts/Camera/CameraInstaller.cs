using UnityEngine;
using Zenject;

namespace SoleNar.Cameras
{
    internal sealed class CameraInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera _camera = null;

        public override void InstallBindings()
        {
            Camera camera = Container.InstantiatePrefabForComponent<Camera>(_camera);
            Container.Bind<Camera>().FromInstance(camera).AsSingle();
        }
    } 
}
