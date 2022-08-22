using SoleNar.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    public class PlayerFuelPresenter
    {
        private IPlayerResource<int> _fuelResource;
        private FuelView _fuelView;

        [Inject]
        public PlayerFuelPresenter(List<IPlayerResource<int>> playerResources, FuelView fuelView)
        {
            _fuelResource = playerResources.SingleOrDefault(resource => resource.ID == "Fuel");
            _fuelView = fuelView;

            _fuelResource.onResourceValueChanged += UpdateView;
        }

        private void UpdateView(int value) => _fuelView.SetFuelImagesCount(value);
    }
}
