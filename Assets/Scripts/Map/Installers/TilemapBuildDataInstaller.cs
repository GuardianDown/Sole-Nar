using UnityEngine;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapBuildDataInstaller : MonoInstaller
    {
        [SerializeField]
        private TilemapBuildData _tilemapBuildData = null;

        public override void InstallBindings() => 
            Container.Bind<ITilemapBuildData>().FromInstance(_tilemapBuildData).AsSingle();
    }
}
