using SoleNar.Input;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapClickHandler : ITilemapClickHandler
    {
        private readonly ITilemapData _tilemapData;
        private readonly Controls _controls;
        private readonly ITilemapCursorPosition _tilemapCursorPosition;

        private string _currentTileID;
        private Vector3Int _currentTilePosition;

        public event Action<string, Vector3Int> onTileClick;

        [Inject]
        public TilemapClickHandler(ITilemapData tilemapData, 
            Controls controls, 
            ITilemapCursorPosition tilemapCursorPosition)
        {
            _tilemapData = tilemapData;
            _controls = controls;
            _tilemapCursorPosition = tilemapCursorPosition;
        }

        public void Enable() => 
            _controls.Map.Click.started += OnMouseDown;

        public void Disable() => 
            _controls.Map.Click.started -= OnMouseDown;

        public void Dispose() => Disable();

        private void OnMouseDown(InputAction.CallbackContext callbackContext)
        {
            _currentTilePosition = _tilemapCursorPosition.Position;
            try
            {
                _currentTileID = _tilemapData.GetTile(_currentTilePosition).ID;
                onTileClick?.Invoke(_currentTileID, _currentTilePosition);
            }
            catch(KeyNotFoundException)
            {
                return;
            }
        }
    }
}