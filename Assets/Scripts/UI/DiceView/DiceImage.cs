using UnityEngine;
using UnityEngine.UI;

namespace SoleNar.UI
{
    internal sealed class DiceImage : MonoBehaviour, IDiceView
    {
        [SerializeField]
        private Image _image = null;

        [SerializeField]
        private Sprite _defaultSprite = null;

        [SerializeField]
        private Sprite[] _sprites = null;

        public void SetValue(int value)
        {
            if (value < 0)
                value = 0;
            else if (value >= _sprites.Length)
                value = _sprites.Length - 1;
            _image.sprite = _sprites[value];
        }

        public void Reset() => _image.sprite = _defaultSprite;
    }
}
