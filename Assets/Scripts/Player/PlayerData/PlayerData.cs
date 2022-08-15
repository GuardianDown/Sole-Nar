using UnityEngine;

namespace SoleNar.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "GameData/PlayerData")]
    internal class PlayerData : ScriptableObject, IPlayerData
    {
        [SerializeField]
        private Vector3Int _startPosition;

        [SerializeField]
        private int _startHelathValue;

        [SerializeField]
        private int _maxHealthValue;

        [SerializeField]
        private int _startFortitudeValue;

        [SerializeField]
        private int _maxFortitudeValue;

        [SerializeField]
        private int _startAttackStreingthValue;

        [SerializeField]
        private int _maxAttackStreingthValue;

        [SerializeField]
        private int _startStealthValue;

        [SerializeField]
        private int _maxStealthValue;

        [SerializeField]
        private int _startFuelValue;

        [SerializeField]
        private int _maxFuelValue;

        [SerializeField]
        private int _startAmoniteValue;

        [SerializeField]
        private int _maxAmoniteValue;

        [SerializeField]
        private int _startRepairKitValue;

        [SerializeField]
        private int _startTorpedoValue;

        [SerializeField]
        private int _startTimeToRestValue;

        public Vector3Int StartPosition => _startPosition;
        public int StartHealthValue => _startHelathValue;
        public int MaxHealthValue => _maxHealthValue;
        public int StartFortitudeValue => _startFortitudeValue;
        public int MaxFortitudeValue => _maxFortitudeValue;
        public int StartAttackStreingthValue => _startAttackStreingthValue;
        public int MaxAttackStreingthValue => _maxAttackStreingthValue;
        public int StartStealthValue => _startStealthValue;
        public int MaxStealthValue => _maxStealthValue;
        public int StartFuelValue => _startFuelValue;
        public int MaxFuelValue => _maxFuelValue;
        public int StartAmoniteValue => _startAmoniteValue;
        public int MaxAmoniteValue => _maxAmoniteValue;
        public int StartRepairKitValue => _startRepairKitValue;
        public int StartTorpedoValue => _startTorpedoValue;
        public int StartTimeToRestValue => _startTimeToRestValue;
    }
}
