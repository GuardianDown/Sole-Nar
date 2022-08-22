using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Events
{
    internal sealed class InspectEventDataInstaller : MonoInstaller
    {
        [SerializeField]
        private InspectEventData[] _inspectEventData = null;

        public override void InstallBindings() => 
            Container.Bind<IEnumerable<InspectEventData>>().FromInstance(_inspectEventData).AsSingle();
    }
}
