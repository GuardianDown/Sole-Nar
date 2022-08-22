using UnityEngine;
using Zenject;

namespace SoleNar.Cameras
{
    internal sealed class CameraInstaller : MonoInstaller
    {
        [SerializeField]
        private Camera _cameraPrefab = null;

        public override void InstallBindings()
        {
            Camera camera = Container.InstantiatePrefabForComponent<Camera>(_cameraPrefab);
            Container.Bind<Camera>().FromInstance(camera).AsSingle();
        }
    } 
}
