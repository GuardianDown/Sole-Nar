using UnityEngine;
using UnityEngine.SceneManagement;

namespace SoleNar.UI
{
    internal sealed class LoadSceneButtonView : ButtonView
    {
        [SerializeField] private string _nextSceneName = string.Empty;

        protected override void OnButtonClick() => SceneManager.LoadSceneAsync(_nextSceneName);
    }
}
