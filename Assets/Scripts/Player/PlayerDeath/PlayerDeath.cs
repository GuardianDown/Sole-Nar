using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerDeath : IPlayerDeath
    {
        [Inject]
        public PlayerDeath([Inject(Id = PlayerResourceIDs.HealthID)] ICriticalPlayerResource<int> playerHealth,
            [Inject(Id = PlayerResourceIDs.FuelID)] ICriticalPlayerResource<int> playerFuel)
        {
            IPlayerDeath playerDeath = this;
            playerHealth.onResourceOver += playerDeath.GameOver;
            playerFuel.onResourceOver += playerDeath.GameOver;
        }

        void IPlayerDeath.GameOver()
        {
            Debug.LogError("GameOver");
        }
    }
}
