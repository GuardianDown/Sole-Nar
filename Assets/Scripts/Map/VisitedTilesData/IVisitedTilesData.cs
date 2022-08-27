using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Map
{
    public interface IVisitedTilesData : IEnumerable<KeyValuePair<Vector3Int, bool>>
    {
        event Action<Vector3Int> onTileVisited;

        void MarkAsVisited(Vector3Int tilePosition);

        bool IsTileVisited(Vector3Int tilePosition);

        void AddTile(Vector3Int tilePosition, bool isVisited);
    }
}
