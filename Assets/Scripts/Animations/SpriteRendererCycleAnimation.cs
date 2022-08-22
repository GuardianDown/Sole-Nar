using UnityEngine;

namespace SoleNar.Animations
{
    public sealed class SpriteRendererCycleAnimation : CycleAnimation
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer = null;

        protected override void SetSprite()
        {
            if (_spriteRenderer)
                _spriteRenderer.sprite = _sprites[_currentSpriteIndex];
        }
    }
}
