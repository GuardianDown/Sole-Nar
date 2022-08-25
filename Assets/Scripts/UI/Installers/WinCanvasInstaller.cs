using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    public class WinCanvasInstaller : MonoInstaller
    {
        [SerializeField]
        private GameWinView _winCanvasPrefab = null;

        public override void InstallBindings() => 
            Container.Bind<GameWinView>().FromInstance(_winCanvasPrefab).AsSingle();
    }
}
