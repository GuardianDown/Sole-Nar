#if UNITY_EDITOR
using UnityEditor;
#else
using UnityEngine;
#endif

namespace SoleNar.UI
{
    internal sealed class QuitButtonView : ButtonView
    {
        protected override void OnButtonClick() => Quit();

        private void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
