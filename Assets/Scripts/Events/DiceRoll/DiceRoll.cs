using UnityEngine;

namespace SoleNar.Events
{
    internal sealed class DiceRoll : IDiceRoll
    {
        private const int RollMinValue = 0;
        private const int RollMaxValue = 6;

        public int MinValue => RollMinValue;
        public int MaxValue => RollMaxValue;

        public int GetResult() => Random.Range(RollMinValue, RollMaxValue);
    }
}
