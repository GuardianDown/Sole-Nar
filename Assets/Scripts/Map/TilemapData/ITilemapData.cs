using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Map
{
    public interface ITilemapData : IEnumerable<KeyValuePair<Vector3Int, ITile>>
    {
        public void AddTile(ITile tile, Vector3Int tilePosition);

        public ITile GetTile(Vector3Int position);
    }
}
