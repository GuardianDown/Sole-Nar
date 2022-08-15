using UnityEngine;
using UnityEngine.Tilemaps;

namespace SoleNar.Map
{
    public interface ITilemapView
    {
        Grid Grid { get; }
        Tilemap Tilemap { get; }
    }
}
