using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using SoleNar.Animations;
using System.Collections.Generic;

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
        private Button _closeButton = null;

        [SerializeField]
        private Image[] _enemyHealthImages = null;

        [SerializeField]
        private TextMeshProUGUI _enemyStreingthText = null;

        [SerializeField]
        private UICycleAnimation _enemyImage = null;

        [SerializeField]
        private DiceImage _diceView = null;

        public event Action onAttack;
        public event Action onRepair;
        public event Action onTorpedo;
        public event Action onClose;

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        public void Enable() => _root.SetActive(true);

        public void Disable() => _root.SetActive(false);

        public void SetEnemy(IEnumerable<Sprite> enemySprites) =>
            _enemyImage.SetSprites(enemySprites);

        public void SetEnemyHealth(int value)
        {
            for (int i = 0; i < _enemyHealthImages.Length; ++i)
                _enemyHealthImages[i].gameObject.SetActive(i < value);
        }

        public void SetEnemyStrenght(int value) => 
            _enemyStreingthText.text = value.ToString();

        public void SetDiceValue(int value) =>
            _diceView.SetValue(value);

        public void EnableCloseButton()
        {
            _attackButton.gameObject.SetActive(false);
            _repairButton.gameObject.SetActive(false);
            _torpedoButton.gameObject.SetActive(false);
            _closeButton.gameObject.SetActive(true);
        }

        public void DisableCloseButton()
        {
            _attackButton.gameObject.SetActive(true);
            _repairButton.gameObject.SetActive(true);
            _torpedoButton.gameObject.SetActive(true);
            _closeButton.gameObject.SetActive(false);
        }

        private void Subscribe()
        {
            _attackButton.onClick.AddListener(OnAttackButtonClick);
            _repairButton.onClick.AddListener(OnRepairButtonClick);
            _torpedoButton.onClick.AddListener(OnTorpedoButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void Unsubscribe()
        {
            _attackButton.onClick.RemoveListener(OnAttackButtonClick);
            _repairButton.onClick.RemoveListener(OnRepairButtonClick);
            _torpedoButton.onClick.RemoveListener(OnTorpedoButtonClick);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        private void OnAttackButtonClick() => onAttack?.Invoke();

        private void OnRepairButtonClick() => onRepair?.Invoke();

        private void OnTorpedoButtonClick() => onTorpedo?.Invoke();

        private void OnCloseButtonClick() => onClose?.Invoke();
    }
}
