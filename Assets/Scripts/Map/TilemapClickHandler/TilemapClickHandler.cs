using SoleNar.Input;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapClickHandler : ITilemapClickHandler
    {
        private readonly ITilemapView _tilemapView;
        private readonly Camera _camera;
        private readonly Controls _controls;

        public event Action<Vector3Int> onTilemapClick;

        [Inject]
        public TilemapClickHandler(ITilemapView tilemapView, Camera camera, Controls controls)
        {
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
            onTilemapClick?.Invoke(cellPosition);
        }
    }
}