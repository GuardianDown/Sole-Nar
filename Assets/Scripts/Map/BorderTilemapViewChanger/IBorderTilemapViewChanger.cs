using System;

namespace SoleNar.Map
{
    public interface IBorderTilemapViewChanger : IDisposable
    {
        void Enable();

        void Disable();
    }
}
