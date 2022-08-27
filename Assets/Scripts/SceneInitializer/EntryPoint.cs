using UnityEngine;
using Zenject;

namespace SoleNar.SceneInitializer
{
    internal sealed class EntryPoint : MonoBehaviour
    {
        private ISceneInitializer _sceneInitializer;

        [Inject]
        private void Construct(ISceneInitializer sceneInitializer)
        {
            _sceneInitializer = sceneInitializer;
            _sceneInitializer.Initialize();
        }

        private void OnDestroy() => _sceneInitializer.Dispose();
    }
}
