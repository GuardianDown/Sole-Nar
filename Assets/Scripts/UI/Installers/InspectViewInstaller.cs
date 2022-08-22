using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    internal sealed class InspectViewInstaller : MonoInstaller
    {
        [SerializeField]
        private InspectEventView _inspectEventViewPrefab = null;

        public override void InstallBindings()
        {
            IInspectEventView inspectEventView = Container.InstantiatePrefabForComponent<IInspectEventView>(_inspectEventViewPrefab);
            Container.Bind<IInspectEventView>().FromInstance(inspectEventView).AsSingle();
            inspectEventView.Disable();
        }
    }
}
