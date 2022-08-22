using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Events
{
    internal sealed class EnemyEventDataInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyEventData[] _battleEventData = null;

        public override void InstallBindings() => 
            Container.Bind<IEnumerable<EnemyEventData>>().FromInstance(_battleEventData).AsSingle();
    }
}
