using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    public class GameOverCanvasInstaller : MonoInstaller
    {
        [SerializeField]
        private GameOverView _menuCanvasPrefab = null;

        public override void InstallBindings() => 
            Container.Bind<GameOverView>().FromInstance(_menuCanvasPrefab).AsSingle();
    }
}
