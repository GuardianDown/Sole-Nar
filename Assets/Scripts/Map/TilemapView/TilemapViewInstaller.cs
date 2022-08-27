using UnityEngine;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapViewInstaller : MonoInstaller
    {
        [SerializeField]
        private Grid _tilemapView = null;

        public override void InstallBindings()
        {
            GameObject tilemap = Container.InstantiatePrefab(_tilemapView);

            Container
                .Bind<ITilemapView>()
                .FromInstance(tilemap.GetComponent<TilemapView>())
                .AsSingle();

            Container
                .Bind<IBorderTilemapView>()
                .FromInstance(tilemap.GetComponent<BorderTilemapView>())
                .AsSingle();
        }
    }
}
