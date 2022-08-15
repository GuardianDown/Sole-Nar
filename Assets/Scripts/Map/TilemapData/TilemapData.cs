using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Map
{
    internal sealed class TilemapData : ITilemapData
    {
        private readonly Dictionary<Vector3Int, ITile> _tilesData = new Dictionary<Vector3Int, ITile>();

        public void AddTile(ITile tile, Vector3Int tilePosition) => 
            _tilesData.Add(tilePosition, tile);

        public ITile GetTile(Vector3Int position) => 
            _tilesData[position];

        public bool HasTile(Vector3Int position) =>
            _tilesData.ContainsKey(position);

        public IEnumerator<KeyValuePair<Vector3Int, ITile>> GetEnumerator() => 
            _tilesData.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            _tilesData.GetEnumerator();
    }
}
