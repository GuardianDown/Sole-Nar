using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Events
{
    [CreateAssetMenu(fileName = "BattleEventData", menuName = "GameData/Events/BattleData")]
    public class EnemyEventData : TileEventData
    {
        [TextArea(5, 20)]
        [SerializeField]
        private string[] _attackTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _retreatTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _battleWinTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _battleLoseTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _stealthSuccessTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _stealthFailedTexts = null;

        [SerializeField]
        private int _upperBoundOfBadResult = 3;

        [SerializeField]
        private string _battleWinResourceID = null;

        [SerializeField]
        private int _battleWinResourceCount;

        public IEnumerable<string> AttackTexts => _attackTexts;
        public IEnumerable<string> RetreatTexts => _retreatTexts;
        public IEnumerable<string> BattleWinTexts => _battleWinTexts;
        public IEnumerable<string> BattleLoseTexts => _battleLoseTexts;
        public IEnumerable<string> StealthSuccessTexts => _stealthSuccessTexts;
        public IEnumerable<string> StrealthFailedTexts => _stealthFailedTexts;
        public int UpperBoundOfBadResult => _upperBoundOfBadResult;
        public string BattleWinResourceID => _battleWinResourceID;
        public int BattleWinResourceCount => _battleWinResourceCount;
    }
}
