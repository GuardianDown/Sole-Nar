using UnityEngine.Tilemaps;

namespace SoleNar.Map
{
    public interface ITile
    {
        TileBase View { get; }
        TileStrategy Strategy { get; }
        bool IsPassable { get; }
    }
}