using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Map
{
    [CreateAssetMenu(fileName = "TilemapBuildData", menuName = "GameData/TilemapBuildData")]
    internal sealed class TilemapBuildData : ScriptableObject, ITilemapBuildData
    {
        [SerializeField] 
        private Tile[] _tiles = null;

        [SerializeField] 
        private int _columns;

        [SerializeField] 
        private int _rows;

        public IReadOnlyCollection<ITile> Tiles => _tiles;
        public int Columns => _columns;
        public int Rows => _rows;
    }
}
