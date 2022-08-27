using SoleNar.UI;
using SoleNar.Player;
using System.Collections.Generic;
using Zenject;
using System;
using SoleNar.Map;

namespace SoleNar.Events
{
    //TODO: REFACTIORING TILE EVENTS!
    internal sealed class InspectTileEvent : TileEvent<InspectEventData, IInspectEventView>
    {
        private readonly IDiceRoll _diceRoll;

        public override event Action onCompleted;

        [Inject]
        public InspectTileEvent(IEnumerable<InspectEventData> inspectEventData,
            IInspectEventView inspectEventView, 
            IDiceRoll diceRoll, 
            IEnumerable<IPlayerResource<int>> playerResources,
            IPlayerMovement playerMovement, 
            IVisitedTilesData visitedTilesData) : base(playerMovement, inspectEventData, inspectEventView, playerResources, visitedTilesData)
        {
            _diceRoll = diceRoll;
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
