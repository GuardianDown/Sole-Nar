using UnityEngine;
using UnityEngine.Tilemaps;

namespace SoleNar.Map
{
    internal sealed class TilemapView : MonoBehaviour, ITilemapView
    {
        [SerializeField] 
        private Tilemap _tilemap = null;

        [SerializeField]
        private Grid _grid = null;

        public Tilemap Tilemap => _tilemap;
        public Grid Grid => _grid;
    }
}
