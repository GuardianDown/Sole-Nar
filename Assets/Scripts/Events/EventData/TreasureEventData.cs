using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Events
{
    [CreateAssetMenu(fileName = "TreasureEventData", menuName = "GameData/Events/TreasureData")]
    public class TreasureEventData : TileEventData
    {
        [TextArea(5, 20)]
        [SerializeField]
        private string[] _attackTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _retreatTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _increaseMaxHealthTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _increaseStealthTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _increaseAttackStreingthTexts = null;

        [SerializeField]
        private EnemyData[] _enemiesData = null;

        public IEnumerable<string> AttackTexts => _attackTexts;
        public IEnumerable<string> RetreatTexts => _retreatTexts;
        public IEnumerable<string> IncreaseMaxHealthTexts => _increaseMaxHealthTexts;
        public IEnumerable<string> IncreaseStealthTexts => _increaseStealthTexts;
        public IEnumerable<string> IncreaseAttackStreingthTexts => _increaseAttackStreingthTexts;
        public IEnumerable<EnemyData> EnemiesData => _enemiesData;
    }
}
