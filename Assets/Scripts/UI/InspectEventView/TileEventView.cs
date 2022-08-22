using SoleNar.Animations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SoleNar.UI
{
    public abstract class TileEventView : MonoBehaviour, ITileEventView
    {
        [SerializeField]
        private GameObject _root = null;

        [SerializeField]
        private TextMeshProUGUI _titleText = null;

        [SerializeField]
        private TextMeshProUGUI _eventText = null;

        [SerializeField]
        private UICycleAnimation _tileImages = null;

        [SerializeField]
        private DiceImage _diceImage = null;

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

        protected abstract void Subscribe();

        protected abstract void Unsubscribe();

        public void Enable() => _root.SetActive(true);

        public void Disable() => _root.SetActive(false);

        public void SetTitle(string title) => _titleText.text = title;

        public void SetEventText(string text) => _eventText.text = text;

        public void SetEventSprites(IEnumerable<Sprite> sprites) => _tileImages.SetSprites(sprites);

        public void SetDiceValue(int value) => _diceImage.SetValue(value);

        public void ResetDiceView() => _diceImage.Reset();
    }
}
