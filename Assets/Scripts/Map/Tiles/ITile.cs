using UnityEngine.Tilemaps;

namespace SoleNar.Map
{
    public interface ITile
    {
        TileBase View { get; }
        string ID { get; }
        bool IsPassable { get; }
    }
}