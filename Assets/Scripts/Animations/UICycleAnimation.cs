using UnityEngine;
using UnityEngine.UI;

namespace SoleNar.Animations
{
    public sealed class UICycleAnimation : CycleAnimation
    {
        [SerializeField]
        private Image _image = null;

        protected override void SetSprite()
        {
            if (_image)
                _image.sprite = _sprites[_currentSpriteIndex];
        }
    }
}
