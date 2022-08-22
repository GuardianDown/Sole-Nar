using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SoleNar.Animations
{
    public abstract class CycleAnimation : MonoBehaviour
    {
        [Header("Delay between sprite change in milliseconds")]
        [SerializeField]
        private int _animationSpeed;

        [SerializeField]
        protected List<Sprite> _sprites = null;

        private CancellationTokenSource _cancellationTokenSource;
        private Task _animationTask;
        protected int _currentSpriteIndex;

        private async void OnEnable() => await StartAnimationTask();

        private void OnDisable() => StopAnimationTask();

        protected abstract void SetSprite();

        public async void SetSprites(IEnumerable<Sprite> sprites)
        {
            StopAnimationTask();
            _sprites = new List<Sprite>(sprites);
            await StartAnimationTask();
        }

        private async Task ChangeSprite(CancellationToken token)
        {
            _currentSpriteIndex = 0;

            try
            {
                while (!token.IsCancellationRequested && _sprites != null && _sprites.Count != 0)
                {
                    SetSprite();
                    ++_currentSpriteIndex;
                    if (_currentSpriteIndex >= _sprites.Count)
                        _currentSpriteIndex = 0;
                    await Task.Delay(_animationSpeed, token);
                }
            }
            catch (TaskCanceledException)
            {
                return;
            }
        }

        private async Task StartAnimationTask()
        {
            if (_animationTask == null)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _animationTask = ChangeSprite(_cancellationTokenSource.Token);
                await _animationTask;
            }
        }

        private void StopAnimationTask()
        {
            if (_animationTask != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _animationTask = null;
            }
        }
    }
}
