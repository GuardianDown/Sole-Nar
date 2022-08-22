using UnityEngine;

namespace SoleNar.UI
{
    internal sealed class SetActiveButton : ActionButtonView
    {
        [SerializeField]
        private bool _isActivate;

        [SerializeField]
        private GameObject[] _objectsToSetActive;

        protected override void OnButtonClick() => SetActive();

        private void SetActive()
        {
            foreach (GameObject obj in _objectsToSetActive)
                obj.SetActive(_isActivate);
        }
    }
}
