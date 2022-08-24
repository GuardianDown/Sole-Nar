using UnityEngine;

namespace SoleNar.Player
{
    [CreateAssetMenu(fileName = "PlayerResource", menuName = "GameData/PlayerResourceInt")]
    internal sealed class PlayerResourceDataInt : ScriptableObject, IPlayerResourceData<int>
    {
        [SerializeField]
        private string _id = null;

        [SerializeField]
        private int _startValue;

        [SerializeField]
        private int _maxValue;

        public string ID => _id;
        public int StartValue => _startValue;
        public int MaxValue => _maxValue;
    }
}