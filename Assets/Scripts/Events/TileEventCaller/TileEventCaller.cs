using SoleNar.Map;
using SoleNar.Player;
using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Events
{
    internal sealed class TileEventCaller : ITileEventCaller
    {
        private readonly ITilemapClickHandler _tilemapClickHandler;
        private readonly IClickValidator _clickValidator;
        private readonly List<ITileEvent> _tileEvents;
        private readonly IPlayerMovement _playerMovement;

        private ITileEvent _currentTileEvent;

        public TileEventCaller(ITilemapClickHandler tilemapClickHandler,  IClickValidator clickValidator, 
            List<ITileEvent> tileEvents, IPlayerMovement playerMovement)
        {
            _tilemapClickHandler = tilemapClickHandler;
            _clickValidator = clickValidator;
            _tileEvents = tileEvents;
            _playerMovement = playerMovement;

            _tilemapClickHandler.onTileClick += CallEvent;
        }

        public void CallEvent(string tileID, Vector3Int tilePosition)
        {
            if (_clickValidator.IsTileValid(_playerMovement.CurrentPosition, tilePosition))
            {
                foreach (ITileEvent tileEvent in _tileEvents)
                {
                    if(tileEvent.TryStartEvent(tileID, tilePosition))
                    {
                        _tilemapClickHandler.Disable();
                        _currentTileEvent = tileEvent;
                        DisableMapClick();
                        Subscribe();
                        return;
                    }
                }
            }
        }

        private void Subscribe()
        {
            if (_currentTileEvent != null)
                Unsubscribe();
            _currentTileEvent.onClosed += EnableMapClick;
        }

        private void Unsubscribe()
        {
            _currentTileEvent.onClosed -= EnableMapClick;
        }

        private void EnableMapClick() => _tilemapClickHandler.Enable();

        private void DisableMapClick() => _tilemapClickHandler.Disable();

    }
}
