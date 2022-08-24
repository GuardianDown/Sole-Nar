using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    public class PanaceniteViewInstaller : MonoInstaller
    {
        [SerializeField]
        private PanaceniteEventView _panaceniteEventViewPrefab = null;

        public override void InstallBindings()
        {
            IPanaceniteEventView panaceniteEventView = 
                Container.InstantiatePrefabForComponent<IPanaceniteEventView>(_panaceniteEventViewPrefab);
            panaceniteEventView.Disable();
            Container.Bind<IPanaceniteEventView>().FromInstance(panaceniteEventView);
        }
    }
}
