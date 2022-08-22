using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    internal sealed class EnemyViewInstaller : MonoInstaller
    {
        [SerializeField]
        private EnemyEventView _battleEventViewPrefab = null;

        public override void InstallBindings()
        {
            IEnemyEventView battleEventView = Container.InstantiatePrefabForComponent<IEnemyEventView>(_battleEventViewPrefab);
            Container.Bind<IEnemyEventView>().FromInstance(battleEventView).AsSingle();
            battleEventView.Disable();
        }
    }
}
