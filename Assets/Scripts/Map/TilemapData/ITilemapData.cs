using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Map
{
    public interface ITilemapData : IEnumerable<KeyValuePair<Vector3Int, ITile>>
    {
        void AddTile(ITile tile, Vector3Int tilePosition);

        ITile GetTile(Vector3Int position);

        bool HasTile(Vector3Int position);
    }
}
