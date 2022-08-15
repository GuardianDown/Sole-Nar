using System;

namespace SoleNar.Player
{
    public interface IPlayerResource<T>
    {
        event Action<T> onResourceValueChanged;

        void Increase(T value);

        void Decrease(T value);
    }
}
