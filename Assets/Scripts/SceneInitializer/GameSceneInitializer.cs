using SoleNar.Map;
using Zenject;

namespace SoleNar.SceneInitializer
{
    internal class GameSceneInitializer : ISceneInitializer
    {
        private readonly ITilemapGenerator _tilemapGenerator;
        private readonly ITilemapClickHandler _tilemapClickHandler;

        [Inject]
        public GameSceneInitializer(ITilemapGenerator tilemapGenerator, ITilemapClickHandler tilemapClickHandler)
        {
            _tilemapGenerator = tilemapGenerator;
            _tilemapClickHandler = tilemapClickHandler;

            Initialize();
        }

        public void Initialize()
        {
            _tilemapGenerator.GenerateTilemap();
            _tilemapClickHandler.Enable();
        }
    }
}