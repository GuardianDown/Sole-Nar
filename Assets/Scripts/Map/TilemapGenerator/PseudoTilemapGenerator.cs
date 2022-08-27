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
        private readonly IBorderTilemapView _borderTilemapView;
        private readonly ITilemapData _tilemapData;
        private readonly IVisitedTilesData _visitedTilesData;

        [Inject]
        public PseudoTilemapGenerator(ITilemapBuildData tilemapBuildData, 
            ITilemapView tilemapView,
            IBorderTilemapView borderTilemapView,
            ITilemapData tilemapData, 
            IVisitedTilesData visitedTilesData)
        {
            _tilemapBuildData = tilemapBuildData;
            _tilemapView = tilemapView;
            _borderTilemapView = borderTilemapView;
            _tilemapData = tilemapData;
            _visitedTilesData = visitedTilesData;
        }

        public void GenerateTilemap()
        {
            CreateTilemap();
            SetTilemapPosition();
        }

        private void CreateTilemap()
        {
            int rows = _tilemapBuildData.Rows;
            int columns = _tilemapBuildData.Columns;
            IReadOnlyCollection<ITile> tiles = _tilemapBuildData.Tiles;

            if (rows > 0 && columns > 0)
            {
                int currentTileIndex;
                int currentRow;
                int currentColumn;
                ITile currentTile;
                Vector3Int currentTilePosition;

                for (int i = 0; i < rows; ++i)
                {
                    for (int j = 0; j < columns; ++j)
                    {
                        currentTileIndex = i * columns + j;
                        if (currentTileIndex >= tiles.Count())
                            return;
                        currentRow = -i + rows / 2 - 1;
                        currentColumn = j - (columns / 2);
                        currentTile = tiles.ElementAt(currentTileIndex);
                        currentTilePosition = new Vector3Int(currentColumn, currentRow, 0);
                        _tilemapData.AddTile(currentTile, currentTilePosition);
                        _visitedTilesData.AddTile(currentTilePosition, !currentTile.IsPassable);
                        _tilemapView.Tilemap.SetTile(currentTilePosition, currentTile.View);
                        _borderTilemapView.Tilemap.SetTile(currentTilePosition,
                            currentTile.IsPassable ? _borderTilemapView.TileActiveBorder : _borderTilemapView.TileUnactiveBorder);
                    }
                }
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
                _tilemapBuildData.Columns % 2 == 0 ? _tilemapView.Tilemap.transform.position.x 
                    : _tilemapView.Tilemap.transform.position.x + _tilemapView.Grid.cellSize.x / -2f,
                _tilemapBuildData.Rows % 2 == 0 ? _tilemapView.Tilemap.transform.position.y 
                    : _tilemapView.Tilemap.transform.position.y + _tilemapView.Grid.cellSize.y / 2f,
                0f
            );
            _tilemapView.Grid.transform.position = tilemapPosition;
        }
    }
}
