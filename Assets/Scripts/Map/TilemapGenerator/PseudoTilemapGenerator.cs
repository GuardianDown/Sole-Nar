using UnityEngine;
using System;
using System.Linq;
using System.Collections.Generic;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class PseudoTilemapGenerator : ITilemapGenerator
    {
        private readonly ITilemapBuildData _tilemapBuildData;
        private readonly ITilemapView _tilemapView;
        private readonly ITilemapData _tilemapData;

        [Inject]
        public PseudoTilemapGenerator(ITilemapBuildData tilemapBuildData, ITilemapView tilemapView, ITilemapData tilemapData)
        {
            _tilemapBuildData = tilemapBuildData;
            _tilemapView = tilemapView;
            _tilemapData = tilemapData;
        }

        public void GenerateTilemap()
        {
            ITilemapData tilemapData = CreateTilemapData();
            SetTilemapPosition();
            InitializeTilemap(tilemapData);
        }

        private ITilemapData CreateTilemapData()
        {
            int rows = _tilemapBuildData.Rows;
            int columns = _tilemapBuildData.Columns;
            IReadOnlyCollection<ITile> tiles = _tilemapBuildData.Tiles;

            if (rows > 0 && columns > 0)
            {
                int currentTileIndex;
                int currentRow;
                int currentColumn;

                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < columns; ++j)
                    {
                        currentTileIndex = i * columns + j;
                        if (currentTileIndex >= tiles.Count())
                            return _tilemapData;
                        currentRow = -i + rows / 2 - 1;
                        currentColumn = j - (columns / 2);
                        _tilemapData.AddTile(tiles.ElementAt(currentTileIndex), new Vector3Int(currentColumn, currentRow, 0));
                    }
                }

                return _tilemapData;
            }
            else
            {
                throw new IndexOutOfRangeException("Column and rows must be greater than 0!");
            }
        }

        private void SetTilemapPosition()
        {
            Vector3 tilemapPosition = new Vector3
            (
                _tilemapBuildData.Columns % 2 == 0 ? 0f : _tilemapView.Grid.cellSize.x / -2f,
                _tilemapBuildData.Rows % 2 == 0 ? 0f : _tilemapView.Grid.cellSize.y / 2f,
                0f
            );
            _tilemapView.Grid.transform.position = tilemapPosition;
        }

        private void InitializeTilemap(ITilemapData tilemapData)
        {
            foreach (KeyValuePair<Vector3Int, ITile> tileData in tilemapData)
            {
                _tilemapView.Tilemap.SetTile(tileData.Key, tileData.Value.View);
            }
        }
    }
}
