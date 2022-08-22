using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerDeath : IPlayerDeath
    {
        public PlayerDeath()
        {
            IPlayerDeath playerDeath = this;
        }

        void IPlayerDeath.GameOver()
        {
            Debug.LogError("GameOver");
        }
    }
}
