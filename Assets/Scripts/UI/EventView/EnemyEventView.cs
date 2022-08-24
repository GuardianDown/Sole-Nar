using System;
using UnityEngine;
using UnityEngine.UI;

namespace SoleNar.UI
{
    internal sealed class EnemyEventView : TileEventView, IEnemyEventView
    {
        [SerializeField]
        private Button _attackButton = null;

        [SerializeField]
        private Button _stealthButton = null;

        [SerializeField]
        private Button _retreatButton = null;

        [SerializeField]
        private Button _closeButton = null;

        public event Action onAttack;
        public event Action onStealth;
        public event Action onRetreat;
        public event Action onClose;

        public void SetEndEventState()
        {
            _attackButton.gameObject.SetActive(false);
            _stealthButton.gameObject.SetActive(false);
            _retreatButton.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(true);
        }

        public void SetStealthFailedState()
        {
            _attackButton.gameObject.SetActive(true);
            _stealthButton.gameObject.SetActive(false);
            _retreatButton.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(false);
        }

        protected override void Subscribe()
        {
            _attackButton.onClick.AddListener(OnAttackButtonClick);
            _stealthButton.onClick.AddListener(OnStealthButtonClick);
            _retreatButton.onClick.AddListener(OnRetreatButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        protected override void Unsubscribe()
        {
            _attackButton.onClick.RemoveListener(OnAttackButtonClick);
            _stealthButton.onClick.RemoveListener(OnStealthButtonClick);
            _retreatButton.onClick.RemoveListener(OnRetreatButtonClick);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        private void OnAttackButtonClick() => onAttack?.Invoke();

        private void OnStealthButtonClick() => onStealth?.Invoke();

        private void OnRetreatButtonClick() => onRetreat?.Invoke();

        private void OnCloseButtonClick() => onClose?.Invoke();
    }
}
