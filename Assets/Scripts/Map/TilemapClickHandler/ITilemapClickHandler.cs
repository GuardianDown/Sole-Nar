using System;
using UnityEngine;

namespace SoleNar.Map
{
    public interface ITilemapClickHandler : IDisposable
    {
        void Enable();

        void Disable();

        event Action<string, Vector3Int> onTileClick;
    }
}
