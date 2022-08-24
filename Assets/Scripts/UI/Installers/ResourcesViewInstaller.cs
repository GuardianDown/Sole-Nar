using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    internal sealed class ResourcesViewInstaller : MonoInstaller
    {
        [SerializeField]
        private Canvas _resourcesCanvas = null;

        public override void InstallBindings() => 
            Container.Bind<IResourceView<int>>().FromComponentsInNewPrefab(_resourcesCanvas).AsSingle();
    }
}
