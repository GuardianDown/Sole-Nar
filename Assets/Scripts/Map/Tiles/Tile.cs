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
        private string _id = null;

        public TileBase View => _view;
        public string ID => _id;
    }
}