using SoleNar.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerDeath : IPlayerDeath
    {
        private readonly GameOverView _gameOverCanvasPrefab;
        private readonly IPlayerResource<int> _playerHealth;
        private readonly IPlayerResource<int> _playerFuel;
        private readonly IPlayerResource<int> _playerFortitude;

        [Inject]
        public PlayerDeath(GameOverView gameOverCanvasPrefab, IEnumerable<IPlayerResource<int>> playerResources)
        {
            _gameOverCanvasPrefab = gameOverCanvasPrefab;
            _playerHealth = playerResources.SingleOrDefault(resource => resource.ID == PlayerResourcesID.HealthID);
            _playerFuel = playerResources.SingleOrDefault(resource => resource.ID == PlayerResourcesID.FuelID);
            _playerFortitude = playerResources.SingleOrDefault(resource => resource.ID == PlayerResourcesID.FortitudeID);

            Subscribe();
        }

        public void GameOver()
        {
            Object.Instantiate(_gameOverCanvasPrefab);
            Unsubscribe();
        }

        private void Subscribe()
        {
            _playerHealth.onResourceValueChanged += OnResourceValueChanged;
            _playerFortitude.onResourceValueChanged += OnResourceValueChanged;
            _playerFuel.onResourceValueChanged += OnResourceValueChanged;
        }

        private void Unsubscribe()
        {
            _playerHealth.onResourceValueChanged -= OnResourceValueChanged;
            _playerFortitude.onResourceValueChanged -= OnResourceValueChanged;
            _playerFuel.onResourceValueChanged -= OnResourceValueChanged;
        }

        private void OnResourceValueChanged(string id, int value)
        {
            if (value <= 0)
                GameOver();
        }
    }
}
