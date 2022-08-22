using SoleNar.Animations;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private SpriteRendererCycleAnimation _playerPrefab = null;

        public override void InstallBindings()
        {
            SpriteRendererCycleAnimation player = Container.InstantiatePrefabForComponent<SpriteRendererCycleAnimation>(_playerPrefab);
            Container.Bind<SpriteRendererCycleAnimation>().FromInstance(player).AsSingle();
        }
    }
}
