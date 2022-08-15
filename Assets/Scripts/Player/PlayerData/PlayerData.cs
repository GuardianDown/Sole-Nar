using UnityEngine;

namespace SoleNar.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "GameData/PlayerData")]
    internal class PlayerData : ScriptableObject, IPlayerData
    {
        [SerializeField]
        private Vector3Int _startPosition;

        public Vector3Int StartPosition => _startPosition;
    }
}
