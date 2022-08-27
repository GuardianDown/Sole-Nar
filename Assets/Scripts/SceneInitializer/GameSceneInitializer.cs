using SoleNar.Events;
using SoleNar.Input;
using SoleNar.Map;
using SoleNar.Player;
using System.Threading;
using Zenject;

namespace SoleNar.SceneInitializer
{
    internal class GameSceneInitializer : ISceneInitializer
    {
        private readonly ITilemapGenerator _tilemapGenerator;
        private readonly Controls _controls;
        private readonly ITilemapCursorPosition _tilemapCursorPosition;
        private readonly ITilemapClickHandler _tilemapClickHandler;
        private readonly IBorderTilemapViewChanger _borderTilemapViewChanger;

        private readonly IPlayerMovement _playerMovement;
        private readonly IPlayerDeath _playerDeath;
        private readonly ITileEventCaller _tileEventCaller;

        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        public GameSceneInitializer(ITilemapGenerator tilemapGenerator,
            Controls controls,
            ITilemapCursorPosition tilemapCursorPosition,
            ITilemapClickHandler tilemapClickHandler,
            IBorderTilemapViewChanger borderTilemapViewChanger,

            IPlayerMovement playerMovement,
            IPlayerDeath playerDeath, 
            IPlayerResourcesPresenter<int> playerFuelPresenter,
            ITileEventCaller tileEventCaller, 
            PlayerWin playerWin)
        {
            _tilemapGenerator = tilemapGenerator;
            _controls = controls;
            _tilemapCursorPosition = tilemapCursorPosition;
            _tilemapClickHandler = tilemapClickHandler;
            _borderTilemapViewChanger = borderTilemapViewChanger;

            _playerMovement = playerMovement;
            _playerDeath = playerDeath;
            _tileEventCaller = tileEventCaller;

            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Initialize()
        {
            _tilemapGenerator.GenerateTilemap();
            _controls.Enable();
            _tilemapCursorPosition.StartTrackPosition(_cancellationTokenSource.Token);
            _tilemapClickHandler.Enable();
            _borderTilemapViewChanger.Enable();
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _controls.Disable();
            _controls.Dispose();
            _tilemapClickHandler.Dispose();
            _borderTilemapViewChanger.Dispose();
        }
    }
}