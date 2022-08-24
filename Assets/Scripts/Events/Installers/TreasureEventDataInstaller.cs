using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Events
{
    internal sealed class TreasureEventDataInstaller : MonoInstaller
    {
        [SerializeField]
        private TreasureEventData[] _treasureEventData = null;

        public override void InstallBindings() => 
            Container.Bind<IEnumerable<TreasureEventData>>().FromInstance(_treasureEventData).AsSingle();
    }
}
