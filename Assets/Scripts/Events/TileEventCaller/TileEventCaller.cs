using SoleNar.Map;
using SoleNar.Player;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Events
{
    internal sealed class TileEventCaller : ITileEventCaller
    {
        private readonly ITilemapClickHandler _tilemapClickHandler;
        private readonly IClickValidator _clickValidator;
        private readonly List<ITileEvent> _tileEvents;
        private readonly IPlayerMovement _playerMovement;
        private readonly IVisitedTilesData _visitedTilesData;

        private ITileEvent _currentTileEvent;
        private Vector3Int _currentTilePosition;

        [Inject]
        public TileEventCaller(ITilemapClickHandler tilemapClickHandler,  IClickValidator clickValidator, 
            List<ITileEvent> tileEvents, IPlayerMovement playerMovement, IVisitedTilesData visitedTilesData)
        {
            _tilemapClickHandler = tilemapClickHandler;
            _clickValidator = clickValidator;
            _tileEvents = tileEvents;
            _playerMovement = playerMovement;
            _visitedTilesData = visitedTilesData;

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
                        _currentTilePosition = tilePosition;
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
            _currentTileEvent.onCompleted += OnEventCompleted;
        }

        private void Unsubscribe()
        {
            _currentTileEvent.onClosed -= EnableMapClick;
            _currentTileEvent.onCompleted -= OnEventCompleted;
        }

        private void EnableMapClick() => _tilemapClickHandler.Enable();

        private void DisableMapClick() => _tilemapClickHandler.Disable();

        private void OnEventCompleted() => _visitedTilesData.MarkAsVisited(_currentTilePosition);
    }
}
