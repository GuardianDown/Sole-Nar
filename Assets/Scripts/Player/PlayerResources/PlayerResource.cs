using System;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    public abstract class PlayerResourceInt : IPlayerResource<int>
    {
        protected readonly IPlayerData _playerData;

        protected int _startValue;
        protected int _maxValue;
        protected int _currentValue;

        public abstract string ID { get; }

        public event Action<int> onResourceValueChanged;

        public PlayerResourceInt(IPlayerData playerData)
        {
            _playerData = playerData;

            _startValue = GetStartValue();
            _maxValue = GetMaxValue();

            if (_maxValue <= 0)
                _maxValue = 1;
            if (_startValue <= 0)
                _startValue = 1;
            if (_startValue > _maxValue)
                _startValue = _maxValue;

            _currentValue = _startValue;
        }

        protected abstract int GetStartValue();

        protected abstract int GetMaxValue();

        public virtual void AddValue(int value)
        {
            _currentValue += value;
            if (_currentValue > _maxValue)
                _currentValue = _maxValue;
            else if (_currentValue <= 0)
                _currentValue = 0;
            onResourceValueChanged?.Invoke(_currentValue);
        }
    }
}
