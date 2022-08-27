using UnityEngine.Tilemaps;

namespace SoleNar.Map
{
    public interface IBorderTilemapView
    {
        Tilemap Tilemap { get; }
        TileBase MouseOverBorder { get; }
        TileBase TileActiveBorder { get; }
        TileBase TileUnactiveBorder { get; }
    }
}
