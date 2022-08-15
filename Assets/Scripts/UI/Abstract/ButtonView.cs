using UnityEngine;
using UnityEngine.UI;

namespace SoleNar.UI
{
    internal abstract class ButtonView : MonoBehaviour
    {
        [SerializeField] protected Button _button = null;

        protected virtual void OnEnable() => Subscribe();

        protected virtual void OnDisable() => Unsubscribe();

        protected abstract void OnButtonClick();

        protected virtual void Subscribe() => _button.onClick.AddListener(OnButtonClick);

        protected virtual void Unsubscribe() => _button.onClick.RemoveListener(OnButtonClick);
    }
}
