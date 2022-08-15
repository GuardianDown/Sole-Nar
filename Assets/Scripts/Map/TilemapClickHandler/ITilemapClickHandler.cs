using System;
using UnityEngine;

namespace SoleNar.Map
{
    public interface ITilemapClickHandler
    {
        void Enable();

        void Disable();

        event Action<Vector3Int> onTilemapClick;
    }
}
