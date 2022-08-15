using UnityEngine;
using UnityEngine.Tilemaps;

namespace SoleNar.Map
{
    [CreateAssetMenu(fileName = "Tile", menuName = "GameData/Tile")]
    internal class Tile : ScriptableObject, ITile
    {
        [SerializeField] 
        private TileBase _view = null;

        [SerializeField] 
        private TileStrategy _strategy = null;

        public TileBase View => _view;
        public TileStrategy Strategy => _strategy;
    }
}