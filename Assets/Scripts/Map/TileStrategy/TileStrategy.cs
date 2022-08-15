using UnityEngine;

namespace SoleNar.Map
{
    public abstract class TileStrategy : ScriptableObject
    {
        public abstract void Execute();
    }
}
