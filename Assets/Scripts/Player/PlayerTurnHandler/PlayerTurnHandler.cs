using SoleNar.Map;
using UnityEngine;

namespace SoleNar.Player
{
    public sealed class PlayerTurnHandler
    {
        private readonly IClickValidator _clickValidator;
        private readonly IPlayerMovement _playerMovement;
        private readonly ITilemapData _tilemapData;
        private readonly ITilemapClickHandler _tilemapClickHandler;

        public PlayerTurnHandler(IClickValidator clickValidator, IPlayerMovement playerMovement, 
            ITilemapData tilemapData, ITilemapClickHandler tilemapClickHandler)
        {
            _clickValidator = clickValidator;
            _playerMovement = playerMovement;
            _tilemapData = tilemapData;
            _tilemapClickHandler = tilemapClickHandler;

            _tilemapClickHandler.onTilemapClick += MakeTurn;
        }

        public void MakeTurn(Vector3Int newPosition)
        {
            if (_clickValidator.IsTileValid(_playerMovement.CurrentPosition, newPosition))
            {
                _playerMovement.Move(newPosition);
                _tilemapData.GetTile(newPosition).Strategy.Execute();
            }
        }
    }
}
