using UnityEngine;

namespace SoleNar.Events
{
    public interface ITileEventCaller
    {
        void CallEvent(string tileID, Vector3Int tilePosition);
    }
}