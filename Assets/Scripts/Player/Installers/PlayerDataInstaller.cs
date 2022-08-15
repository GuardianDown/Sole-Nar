using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerDataInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerData _playerData = null;

        public override void InstallBindings() => 
            Container.Bind<IPlayerData>().FromInstance(_playerData).AsSingle();
    }
}
