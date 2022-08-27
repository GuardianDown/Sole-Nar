using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

namespace SoleNar.Map
{
    internal sealed class BorderTilemapViewChanger : IBorderTilemapViewChanger
    {
        private readonly IBorderTilemapView _borderTilemapView;
        private readonly IVisitedTilesData _visitedTilesData;
        private readonly ITilemapCursorPosition _tilemapCursorPosition;

        private Vector3Int? _previousTilePosition = null;

        [Inject]
        public BorderTilemapViewChanger(IBorderTilemapView borderTilemapView, 
            IVisitedTilesData visitedTIlesData,
            ITilemapCursorPosition tilemapCursorPosition)
        {
            _borderTilemapView = borderTilemapView;
            _visitedTilesData = visitedTIlesData;
            _tilemapCursorPosition = tilemapCursorPosition;
        }

        public void Enable() => 
            _tilemapCursorPosition.onPositionChanged += Change;

        public void Disable() => 
            _tilemapCursorPosition.onPositionChanged -= Change;

        public void Dispose() => Disable();

        private void Change(Vector3Int tilePosition)
        {
            if (_previousTilePosition == null)
                _previousTilePosition = tilePosition;
            else
            {
                SetTile(_previousTilePosition.Value, _borderTilemapView.TileUnactiveBorder, _borderTilemapView.TileActiveBorder);
                _previousTilePosition = tilePosition;
            }

            SetTile(tilePosition, _borderTilemapView.TileUnactiveBorder, _borderTilemapView.MouseOverBorder);
        }

        private void SetTile(Vector3Int tilePosition, TileBase visitedBorder, TileBase nonVisitedBorder)
        {
            try
            {
                _borderTilemapView.Tilemap.SetTile
                    (tilePosition,
                    _visitedTilesData.IsTileVisited(tilePosition) ? visitedBorder : nonVisitedBorder);
            }
            catch(KeyNotFoundException)
            {
                return;
            }
        }
    }
}
