using System;
using UnityEngine;
using UnityEngine.UI;

namespace SoleNar.UI
{
    public class PanaceniteEventView : TileEventView, IPanaceniteEventView
    {
        [SerializeField]
        private Button _inspectButton = null;

        [SerializeField]
        private Button _closeButton = null;

        public event Action onInspect;
        public event Action onClose;

        protected override void Subscribe()
        {
            _inspectButton.onClick.AddListener(OnInspectButtonClick);
            _closeButton.onClick.AddListener(OnCloseButtonClick);
        }

        protected override void Unsubscribe()
        {
            _inspectButton.onClick.RemoveListener(OnInspectButtonClick);
            _closeButton.onClick.RemoveListener(OnInspectButtonClick);
        }

        private void OnInspectButtonClick() => onInspect?.Invoke();

        private void OnCloseButtonClick() => onClose?.Invoke();
    }
}
