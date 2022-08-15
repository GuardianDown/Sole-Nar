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

        public virtual void Increase(int value)
        {
            _currentValue += value;
            if (_currentValue > _maxValue)
                _currentValue = _maxValue;
            onResourceValueChanged?.Invoke(_currentValue);
            Debug.LogError(_currentValue);
        }

        public virtual void Decrease(int value)
        {
            _currentValue -= value;
            if (_currentValue <= 0)
                _currentValue = 0;
            onResourceValueChanged?.Invoke(_currentValue);
            Debug.LogError(_currentValue);
        }
    }
}
