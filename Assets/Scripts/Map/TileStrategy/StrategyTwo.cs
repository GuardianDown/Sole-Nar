using UnityEngine;

namespace SoleNar.Map
{
    [CreateAssetMenu(fileName = "StrategyTwo", menuName = "GameData/Strategy/StrategyTwo")]
    internal sealed class StrategyTwo : TileStrategy
    {
        public override void Execute()
        {
            Debug.Log("Two");
        }
    }
}