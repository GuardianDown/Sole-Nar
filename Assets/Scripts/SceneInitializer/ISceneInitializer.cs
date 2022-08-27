using System;

namespace SoleNar.SceneInitializer
{
    public interface ISceneInitializer : IDisposable
    {
        void Initialize();
    }
}
