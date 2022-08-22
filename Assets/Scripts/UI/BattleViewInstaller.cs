using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    public class BattleViewInstaller : MonoInstaller
    {
        [SerializeField]
        private BattleView _battleViewPrefab = null;

        public override void InstallBindings()
        {
            BattleView battleView = Container.InstantiatePrefabForComponent<BattleView>(_battleViewPrefab);
            Container.Bind<BattleView>().FromInstance(battleView);
            battleView.Disable();
        }
    }
}
