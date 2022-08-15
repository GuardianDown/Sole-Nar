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
        private readonly IPlayerTurnHandler _playerTurnHandler;
        private readonly IPlayerDeath _playerDeath;

        [Inject]
        public GameSceneInitializer(ITilemapGenerator tilemapGenerator, ITilemapClickHandler tilemapClickHandler,
            IPlayerMovement playerMovement, IPlayerData playerData, IPlayerTurnHandler playerTurnHandler,
            IPlayerDeath playerDeath)
        {
            _tilemapGenerator = tilemapGenerator;
            _tilemapClickHandler = tilemapClickHandler;

            _playerMovement = playerMovement;
            _playerData = playerData;
            _playerTurnHandler = playerTurnHandler;
            _playerDeath = playerDeath;

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