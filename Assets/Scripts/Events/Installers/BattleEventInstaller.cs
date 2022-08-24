using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Events
{
    public class BattleEventInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BattleEvent>().AsSingle();
        }
    }
}