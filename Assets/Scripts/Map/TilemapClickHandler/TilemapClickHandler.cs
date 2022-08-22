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
        private readonly ITilemapView _tilemapView;
        private readonly ITilemapData _tilemapData;
        private readonly Camera _camera;
        private readonly Controls _controls;

        public event Action<string, Vector3Int> onTileClick;

        [Inject]
        public TilemapClickHandler(ITilemapView tilemapView, ITilemapData tilemapData, Camera camera, Controls controls)
        {
            _tilemapView = tilemapView;
            _tilemapData = tilemapData;
            _camera = camera;
            _controls = controls;

            _controls.Enable();
        }

        public void Enable() => 
            _controls.Map.Click.started += OnMouseDown;

        public void Disable() => 
            _controls.Map.Click.started -= OnMouseDown;

        private void OnMouseDown(InputAction.CallbackContext callbackContext)
        {
            Vector2 clickPosition = _controls.Map.Position.ReadValue<Vector2>();
            Vector3Int cellPosition = _tilemapView.Tilemap.WorldToCell(_camera.ScreenToWorldPoint(clickPosition));
            string tileID;
            try
            {
                tileID = _tilemapData.GetTile(cellPosition).ID;
            }
            catch(KeyNotFoundException)
            {
                return;
            }
            onTileClick?.Invoke(tileID, cellPosition);
        }
    }
}