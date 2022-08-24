using System;

namespace SoleNar.Player
{
    public interface IPlayerResource<T>
    {
        public string ID { get; }
        public T CurrentValue { get; }

        event Action<string, T> onResourceValueChanged;

        void AddValue(T value);

        void SubtractValue(T value);
    }
}
