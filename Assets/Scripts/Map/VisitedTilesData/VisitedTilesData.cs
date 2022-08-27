using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Map
{
    internal sealed class VisitedTilesData : IVisitedTilesData
    {
        private Dictionary<Vector3Int, bool> _visitedTiles = new Dictionary<Vector3Int, bool>();

        public event Action<Vector3Int> onTileVisited;

        public void MarkAsVisited(Vector3Int tilePosition)
        {
            _visitedTiles[tilePosition] = true;
            onTileVisited?.Invoke(tilePosition);
        }

        public bool IsTileVisited(Vector3Int tilePosition) => 
            _visitedTiles[tilePosition];

        public void AddTile(Vector3Int tilePosition, bool isVisited) => 
            _visitedTiles.Add(tilePosition, isVisited);

        public IEnumerator<KeyValuePair<Vector3Int, bool>> GetEnumerator() =>
             _visitedTiles.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _visitedTiles.GetEnumerator();
    }
}
