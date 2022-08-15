using SoleNar.Map;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class ClickValidator : IClickValidator
    {
        private readonly ITilemapData _tilemapData;

        [Inject]
        public ClickValidator(ITilemapData tilemapData) => 
            _tilemapData = tilemapData;

        public bool IsTileValid(Vector3Int currentPosition, Vector3Int newPosition) =>
            _tilemapData.HasTile(newPosition) &&
            _tilemapData.GetTile(newPosition).IsPassable &&
            ((Mathf.Abs(currentPosition.x - newPosition.x) < 2 && Mathf.Abs(currentPosition.y - newPosition.y) == 0) ||
            (Mathf.Abs(currentPosition.x - newPosition.x) == 0 && Mathf.Abs(currentPosition.y - newPosition.y) < 2));
    }
}
