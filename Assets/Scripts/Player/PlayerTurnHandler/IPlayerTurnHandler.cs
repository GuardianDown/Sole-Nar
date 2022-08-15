using UnityEngine;

namespace SoleNar.Player
{
    public interface IPlayerTurnHandler
    {
        void MakeTurn(Vector3Int newPosition);
    }
}
