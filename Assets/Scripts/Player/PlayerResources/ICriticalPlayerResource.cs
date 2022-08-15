using System;

namespace SoleNar.Player
{
    public interface ICriticalPlayerResource<T> : IPlayerResource<T>
    {
        event Action onResourceOver;
    }
}
