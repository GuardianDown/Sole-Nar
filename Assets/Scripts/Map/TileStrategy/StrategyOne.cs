using UnityEngine;

namespace SoleNar.Map
{
    [CreateAssetMenu(fileName = "StrategyOne", menuName = "GameData/Strategy/StrategyOne")]
    internal sealed class StrategyOne : TileStrategy
    {
        public override void Execute()
        {
            Debug.Log("One");
        }
    }
}