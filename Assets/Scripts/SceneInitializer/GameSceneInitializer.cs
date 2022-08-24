using SoleNar.Events;
using SoleNar.Map;
using SoleNar.Player;
using SoleNar.UI;
using System.Collections.Generic;
using Zenject;

namespace SoleNar.SceneInitializer
{
    internal class GameSceneInitializer : ISceneInitializer
    {
        private readonly ITilemapGenerator _tilemapGenerator;
        private readonly ITilemapClickHandler _tilemapClickHandler;

        private readonly IPlayerMovement _playerMovement;
        private readonly IPlayerDeath _playerDeath;

        private readonly ITileEventCaller _tileEventCaller;

        [Inject]
        public GameSceneInitializer(ITilemapGenerator tilemapGenerator, ITilemapClickHandler tilemapClickHandler,
            IPlayerMovement playerMovement,
            IPlayerDeath playerDeath, IPlayerResourcesPresenter<int> playerFuelPresenter,
            ITileEventCaller tileEventCaller)
        {
            _tilemapGenerator = tilemapGenerator;
            _tilemapClickHandler = tilemapClickHandler;

            _playerMovement = playerMovement;
            _playerDeath = playerDeath;

            _tileEventCaller = tileEventCaller;

            Initialize();
        }

        public void Initialize()
        {
            _tilemapGenerator.GenerateTilemap();
            _tilemapClickHandler.Enable();
        }
    }
}