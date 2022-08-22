using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoleNar.UI
{
    internal sealed class LoadSceneButtonView : ActionButtonView
    {
        [SerializeField] private string _nextSceneName = string.Empty;

        protected override void OnButtonClick() => SceneManager.LoadSceneAsync(_nextSceneName);
    }
}
