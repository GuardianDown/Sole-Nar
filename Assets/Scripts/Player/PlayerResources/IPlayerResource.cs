using System;

namespace SoleNar.Player
{
    public interface IPlayerResource<T>
    {
        public string ID { get; }

        event Action<T> onResourceValueChanged;

        void AddValue(int value);
    }
}
