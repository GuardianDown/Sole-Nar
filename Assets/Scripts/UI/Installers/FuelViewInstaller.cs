using UnityEngine;
using Zenject;

namespace SoleNar.UI
{
    internal sealed class FuelViewInstaller : MonoInstaller
    {
        [SerializeField]
        private FuelView _fuelView = null;

        public override void InstallBindings() => 
            Container.Bind<FuelView>().FromComponentInNewPrefab(_fuelView).AsSingle();
    }
}
