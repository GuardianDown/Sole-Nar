using UnityEngine;
using Zenject;

namespace SoleNar.SceneInitializer
{
    internal sealed class EntryPoint : MonoBehaviour
    {
        [Inject]
        private void Construct(ISceneInitializer sceneInitializer)
        {

        }
    }
}
