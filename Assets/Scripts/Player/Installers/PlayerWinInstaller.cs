using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    public class PlayerWinInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerWin>().AsSingle();
        }
    }
}
