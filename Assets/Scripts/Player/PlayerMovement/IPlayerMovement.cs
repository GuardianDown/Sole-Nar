using UnityEngine;

namespace SoleNar.Player
{
    public interface IPlayerMovement
    {
        Vector3Int CurrentPosition { get; }

        void Move(Vector3Int newPosition);
    }
}
