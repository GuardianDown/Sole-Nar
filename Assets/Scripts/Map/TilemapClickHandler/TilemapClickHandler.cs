using SoleNar.Input;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SoleNar.Map
{
    public class TilemapClickHandler : ITilemapClickHandler
    {
        private readonly ITilemapData _tilemapData;
        private readonly ITilemapView _tilemapView;
        private readonly Camera _camera;
        private readonly Controls _controls;

        [Inject]
        public TilemapClickHandler(ITilemapData tilemapData, ITilemapView tilemapView, Camera camera, Controls controls)
        {
            _tilemapData = tilemapData;
            _tilemapView = tilemapView;
            _camera = camera;
            _controls = controls;

            _controls.Enable();
        }

        public void Enable() => 
            _controls.Map.Click.started += CallTileEvent;

        public void Disable() => 
            _controls.Map.Click.started -= CallTileEvent;

        public void CallTileEvent(InputAction.CallbackContext callbackContext)
        {
            Vector2 clickPosition = _controls.Map.Position.ReadValue<Vector2>();
            Vector3Int cellPosition = _tilemapView.Tilemap.WorldToCell(_camera.ScreenToWorldPoint(clickPosition));

            try
            {
                _tilemapData.GetTile(cellPosition).Strategy.Execute();
            }
            catch (KeyNotFoundException)
            {
                return;
            }
        }
    }
}