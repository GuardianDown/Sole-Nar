using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace SoleNar.UI
{
    public class BattleView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _root = null;

        [SerializeField]
        private Button _attackButton = null;

        [SerializeField]
        private Button _repairButton = null;

        [SerializeField]
        private Button _torpedoButton = null;

        [SerializeField]
        private Image[] _enemyHealthImages = null;

        [SerializeField]
        private TextMeshProUGUI _enemyStreingthText = null;

        public event Action onAttack;
        public event Action onRepair;
        public event Action onTorpedo;

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        public void Enable() => _root.SetActive(true);

        public void Disable() => _root.SetActive(false);

        private void Subscribe()
        {
            _attackButton.onClick.AddListener(OnAttackButtonClick);
            _repairButton.onClick.AddListener(OnRepairButtonClick);
            _torpedoButton.onClick.AddListener(OnTorpedoButtonClick);
        }

        private void Unsubscribe()
        {
            _attackButton.onClick.RemoveListener(OnAttackButtonClick);
            _repairButton.onClick.RemoveListener(OnRepairButtonClick);
            _torpedoButton.onClick.RemoveListener(OnTorpedoButtonClick);
        }

        private void OnAttackButtonClick() => onAttack?.Invoke();

        private void OnRepairButtonClick() => onRepair?.Invoke();

        private void OnTorpedoButtonClick() => onTorpedo?.Invoke();
    }
}
