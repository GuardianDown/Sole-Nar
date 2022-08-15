using UnityEngine;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapViewInstaller : MonoInstaller
    {
        [SerializeField]
        private TilemapView _tilemapView = null;

        public override void InstallBindings()
        {
            ITilemapView tilemap = Container.InstantiatePrefabForComponent<ITilemapView>(_tilemapView);
            Container.Bind<ITilemapView>().FromInstance(tilemap).AsSingle();
        }
    }
}
