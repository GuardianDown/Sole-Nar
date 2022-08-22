using SoleNar.UI;
using SoleNar.Player;
using System.Collections.Generic;
using Zenject;
using System;

namespace SoleNar.Events
{
    internal sealed class InspectTileEvent : TileEvent<InspectEventData, IInspectEventView>
    {
        private readonly List<IPlayerResource<int>> _playerResources;
        private readonly IDiceRoll _diceRoll;

        public override event Action onCompleted;
        public override event Action onIgnored;

        [Inject]
        public InspectTileEvent(IEnumerable<InspectEventData> inspectEventData,
            IInspectEventView inspectEventView, 
            IDiceRoll diceRoll, 
            List<IPlayerResource<int>> playerResources,
            IPlayerMovement playerMovement) : base(playerMovement, inspectEventData, inspectEventView)
        {
            _diceRoll = diceRoll;
            _playerResources = playerResources;
        }

        protected override void Subscribe()
        {
            _eventView.onInspect += Inspect;
            _eventView.onIgnore += Ignore;
            _eventView.onClose += EndEvent;
        }

        protected override void Unsubscribe()
        {
            _eventView.onInspect -= Inspect;
            _eventView.onIgnore -= Ignore;
            _eventView.onClose -= EndEvent;
        }

        private void Inspect()
        {
            int result = _diceRoll.GetResult();
            _eventView.SetDiceValue(result);
            SetResults(result);
            Move();
            onCompleted?.Invoke();
        }

        private void Ignore()
        {
            SetRandomText(_currentEventData.IgnoreTexts);
            Move();
            onIgnored?.Invoke();
        }

        private void SetResults(int diceValue)
        {
            if (diceValue < _currentEventData.UpperBoundOfBadResult)
            {
                SetRandomText(_currentEventData.BadResultTexts);
                ChangeResourcesValue(_currentEventData.BadResultResourceID, _currentEventData.BadResultResourceCount);
            }
            else if (diceValue < _currentEventData.UpperBoundOfAverageResult)
            {
                SetRandomText(_currentEventData.AverageResultTexts);
                ChangeResourcesValue(_currentEventData.AverageResultResourceID, _currentEventData.AverageResultResourceCount);
            }
            else
            {
                SetRandomText(_currentEventData.GoodResultTexts);
                ChangeResourcesValue(_currentEventData.GoodResultResourceID, _currentEventData.GoodResultResourceCount);
            }
        }

        private void ChangeResourcesValue(string resourceID, int resourceCount)
        {
            foreach (IPlayerResource<int> resource in _playerResources)
            {
                if (resource.ID == resourceID)
                {
                    resource.AddValue(resourceCount);
                    return;
                }
            }
        }
    }
}
