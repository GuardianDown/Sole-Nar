using UnityEngine;
using UnityEngine.UI;
using System;

namespace SoleNar.UI
{
    internal sealed class InspectEventView : TileEventView, IInspectEventView
    {
        [SerializeField]
        private Button _inspectButton = null;

        [SerializeField]
        private Button _ignoreButton = null;

        [SerializeField]
        private Button _closeButton = null;

        public event Action onInspect;
        public event Action onIgnore;
        public event Action onClose;

        protected override void Subscribe()
        {
            _inspectButton.onClick.AddListener(OnInspectButtonClick);
            _ignoreButton.onClick.AddListener(OnIgnoreButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        protected override void Unsubscribe()
        {
            _inspectButton.onClick.RemoveListener(OnInspectButtonClick);
            _ignoreButton.onClick.RemoveListener(OnIgnoreButtonClick);
            _closeButton.onClick.RemoveListener(OnCloseButtonClick);
        }

        private void OnInspectButtonClick() => onInspect?.Invoke();

        private void OnIgnoreButtonClick() => onIgnore?.Invoke();

        private void OnCloseButtonClick() => onClose?.Invoke();
    }
}
