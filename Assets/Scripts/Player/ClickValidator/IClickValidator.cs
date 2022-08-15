using UnityEngine;

namespace SoleNar.Player
{
    public interface IClickValidator
    {
        bool IsTileValid(Vector3Int currentPosition, Vector3Int newPosition);
    }
}
