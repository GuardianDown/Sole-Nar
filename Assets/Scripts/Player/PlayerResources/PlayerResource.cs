using System;
using UnityEngine;

namespace SoleNar.Player
{
    internal sealed class PlayerResource : IPlayerResource<int>
    {
        private readonly string _id;

        private int _startValue;
        private int _currentValue;
        private int _maxValue;

        public string ID => _id;
        public int CurrentValue => _currentValue;

        public event Action<string, int> onResourceValueChanged;

        public PlayerResource(IPlayerResourceData<int> data)
        {
            _id = data.ID;
            _startValue = data.StartValue;
            _maxValue = data.MaxValue;

            if (_startValue < 0)
                _startValue = 0;
            if (_maxValue < 0)
                _maxValue = 0;
            if (_startValue > _maxValue)
                _startValue = _maxValue;

            _currentValue = _startValue;
        }

        public void AddValue(int value)
        {
            _currentValue = Mathf.Clamp(_currentValue + value, 0, _maxValue);
            onResourceValueChanged.Invoke(_id, _currentValue);
        }

        public void SubtractValue(int value)
        {
            _currentValue = Mathf.Clamp(_currentValue - value, 0, _maxValue);
            onResourceValueChanged.Invoke(_id, _currentValue);
        }
    }
}
