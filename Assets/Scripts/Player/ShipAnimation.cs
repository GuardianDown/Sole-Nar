using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SoleNar.Player
{
    public sealed class ShipAnimation : MonoBehaviour
    {
        [SerializeField]
        private Sprite[] _shipSprites = null;

        [Header("Delay between sprite change in milliseconds")]
        [SerializeField]
        private int _animationSpeed;

        [SerializeField]
        private SpriteRenderer _shipSpriteRenderer = null;

        private CancellationTokenSource cancellationTokenSource;

        private void Awake()
        {
            cancellationTokenSource = new CancellationTokenSource();
            ChangeSprite(cancellationTokenSource.Token);
        }

        private void OnDestroy()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }

        private async void ChangeSprite(CancellationToken token)
        {
            int currentSpriteIndex = 0;

            try
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Delay(_animationSpeed, token);
                    ++currentSpriteIndex;
                    if (currentSpriteIndex >= _shipSprites.Length)
                        currentSpriteIndex = 0;
                    if(_shipSpriteRenderer)
                        _shipSpriteRenderer.sprite = _shipSprites[currentSpriteIndex];
                }
            }
            catch(TaskCanceledException)
            {
                return;
            }
        }
    }
}
