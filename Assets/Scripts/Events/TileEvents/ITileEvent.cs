using System;
using UnityEngine;

namespace SoleNar.Events
{
    public interface ITileEvent
    {
        event Action onCompleted;
        event Action onIgnored;

        bool TryStartEvent(string tileID, Vector3Int tilePosition);
    }
}
