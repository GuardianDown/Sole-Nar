using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Events
{
    internal sealed class PanaceniteEventDataInstaller : MonoInstaller
    {
        [SerializeField]
        private PanaceniteEventData[] _panaceniteEventData = null;

        public override void InstallBindings() => 
            Container.Bind<IEnumerable<PanaceniteEventData>>().FromInstance(_panaceniteEventData).AsSingle();
    }
}
