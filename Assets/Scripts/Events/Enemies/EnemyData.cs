using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Events
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "GameData/EnemyData")]
    public class EnemyData : ScriptableObject
    {
        [SerializeField]
        private Sprite[] _enemySprites = null;

        [SerializeField]
        private int _attackStrenght;

        [SerializeField]
        private int _health;

        public IEnumerable<Sprite> EnemySprites => _enemySprites;
        public int AttackStrenght => _attackStrenght;
        public int Health => _health;
    }
}
