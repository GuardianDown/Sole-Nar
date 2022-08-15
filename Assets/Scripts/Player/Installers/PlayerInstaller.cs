using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private ShipAnimation _playerPrefab = null;

        public override void InstallBindings()
        {
            ShipAnimation player = Container.InstantiatePrefabForComponent<ShipAnimation>(_playerPrefab);
            Container.Bind<ShipAnimation>().FromInstance(player).AsSingle();
        }
    }
}
