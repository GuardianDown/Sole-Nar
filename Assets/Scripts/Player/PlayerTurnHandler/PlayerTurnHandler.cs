using SoleNar.Map;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerTurnHandler : IPlayerTurnHandler
    {
        private readonly IClickValidator _clickValidator;
        private readonly IPlayerMovement _playerMovement;
        private readonly ITilemapData _tilemapData;
        private readonly ITilemapClickHandler _tilemapClickHandler;
        private readonly IPlayerResource<int> _playerFuel;

        public PlayerTurnHandler(IClickValidator clickValidator, IPlayerMovement playerMovement, 
            ITilemapData tilemapData, ITilemapClickHandler tilemapClickHandler,
            [Inject(Id = PlayerResourceIDs.FuelID)] ICriticalPlayerResource<int> playerFuel)
        {
            _clickValidator = clickValidator;
            _playerMovement = playerMovement;
            _tilemapData = tilemapData;
            _tilemapClickHandler = tilemapClickHandler;
            _playerFuel = playerFuel;

            _tilemapClickHandler.onTilemapClick += ((IPlayerTurnHandler)this).MakeTurn;
        }

        void IPlayerTurnHandler.MakeTurn(Vector3Int newPosition)
        {
            if (_clickValidator.IsTileValid(_playerMovement.CurrentPosition, newPosition))
            {
                ITile currentTile = _tilemapData.GetTile(newPosition);
                _playerMovement.Move(newPosition);
                _playerFuel.Decrease(currentTile.WasteOfFuel);
                currentTile.Strategy.Execute();
            }
        }
    }
}
