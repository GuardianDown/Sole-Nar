using UnityEngine;

namespace SoleNar.Events
{
    internal sealed class DiceRoll : IDiceRoll
    {
        public int GetResult() => Random.Range(0, 6);
    }
}
