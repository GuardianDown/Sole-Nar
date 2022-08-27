using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SoleNar.Map
{
    public interface ITilemapCursorPosition
    {
        Vector3Int Position { get; }

        event Action<Vector3Int> onPositionChanged;

        void StartTrackPosition(CancellationToken token);
    }
}
