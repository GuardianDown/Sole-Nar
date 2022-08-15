using SoleNar.Map;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerMovement : IPlayerMovement
    {
        private readonly ShipAnimation _player;
        private readonly ITilemapView _tilemapView;

        private Vector3Int _currentPosition;
        private Vector3 _positionOffset;

        public Vector3Int CurrentPosition => _currentPosition;

        [Inject]
        public PlayerMovement(ShipAnimation player, ITilemapView tilemapView)
        {
            _player = player;
            _tilemapView = tilemapView;

            _positionOffset = _tilemapView.Tilemap.cellSize / 2f;
        }

        public void Move(Vector3Int newPosition)
        {
            _player.transform.position = _tilemapView.Tilemap.CellToWorld(newPosition) + _positionOffset;
            _currentPosition = newPosition;
        }
    }
}
