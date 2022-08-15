using SoleNar.Map;
using SoleNar.Player;
using Zenject;

namespace SoleNar.SceneInitializer
{
    internal class GameSceneInitializer : ISceneInitializer
    {
        private readonly ITilemapGenerator _tilemapGenerator;
        private readonly ITilemapClickHandler _tilemapClickHandler;

        private readonly IPlayerMovement _playerMovement;
        private readonly IPlayerData _playerData;
        private readonly PlayerTurnHandler _playerTurnHandler;

        [Inject]
        public GameSceneInitializer(ITilemapGenerator tilemapGenerator, ITilemapClickHandler tilemapClickHandler,
            IPlayerMovement playerMovement, IPlayerData playerData, PlayerTurnHandler playerTurnHandler)
        {
            _tilemapGenerator = tilemapGenerator;
            _tilemapClickHandler = tilemapClickHandler;

            _playerMovement = playerMovement;
            _playerData = playerData;
            _playerTurnHandler = playerTurnHandler;

            Initialize();
        }

        public void Initialize()
        {
            _tilemapGenerator.GenerateTilemap();
            _tilemapClickHandler.Enable();

            _playerMovement.Move(_playerData.StartPosition);
        }
    }
}