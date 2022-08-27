using SoleNar.Input;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class TilemapCursorPosition : ITilemapCursorPosition
    {
        private readonly Controls _controls;
        private readonly IBorderTilemapView _borderTilemapView;
        private readonly Camera _camera;

        private Vector3Int _position;

        public Vector3Int Position => _position;

        public event Action<Vector3Int> onPositionChanged;

        [Inject]
        public TilemapCursorPosition(Controls controls, 
            IBorderTilemapView borderTilemapView,
            Camera camera)
        {
            _controls = controls;
            _borderTilemapView = borderTilemapView;
            _camera = camera;
        }

        public async void StartTrackPosition(CancellationToken token)
        {
            Vector2 mousePosition;
            Vector3Int newPosition;

            try
            {
                while (!token.IsCancellationRequested)
                {
                    mousePosition = _controls.Map.Position.ReadValue<Vector2>();
                    newPosition = _borderTilemapView.Tilemap.WorldToCell(_camera.ScreenToWorldPoint(mousePosition));
                    if (newPosition != _position)
                    {
                        _position = newPosition;
                        onPositionChanged?.Invoke(_position);
                    }
                    await Task.Yield();
                }
            }
            catch(TaskCanceledException)
            {
                return;
            }
        }
    }
}
