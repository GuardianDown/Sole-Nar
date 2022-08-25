using SoleNar.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    public class PlayerWin
    {
        private IPlayerResource<int> _playerPanacenite;
        private GameWinView _winCanvasPrefab;

        [Inject]
        public PlayerWin(IEnumerable<IPlayerResource<int>> playerResources, GameWinView winCanvasPrefab)
        {
            _playerPanacenite = playerResources.SingleOrDefault(resource => resource.ID == PlayerResourcesID.PanaceniteID);
            _playerPanacenite.onResourceValueChanged += OnPanaceniteValueChanged;
            _winCanvasPrefab = winCanvasPrefab;
        }

        private void Win()
        {
            Object.Instantiate(_winCanvasPrefab);
        }

        private void OnPanaceniteValueChanged(string id, int value)
        {
            if(value >= 3)
            {
                Win();
                _playerPanacenite.onResourceValueChanged -= OnPanaceniteValueChanged;
            }
        }
    }
}
