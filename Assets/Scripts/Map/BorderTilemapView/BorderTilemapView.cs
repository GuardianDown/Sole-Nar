using UnityEngine;
using UnityEngine.Tilemaps;

namespace SoleNar.Map
{
    internal sealed class BorderTilemapView : MonoBehaviour, IBorderTilemapView
    {
        [SerializeField]
        private Tilemap _tilemap = null;

        [SerializeField]
        private TileBase _mouseOverBorder = null;

        [SerializeField]
        private TileBase _tileActiveBorder = null;

        [SerializeField]
        private TileBase _tileUnactiveBorder = null;

        public Tilemap Tilemap => _tilemap;
        public TileBase MouseOverBorder => _mouseOverBorder;
        public TileBase TileActiveBorder => _tileActiveBorder;
        public TileBase TileUnactiveBorder => _tileUnactiveBorder;
    }
}
