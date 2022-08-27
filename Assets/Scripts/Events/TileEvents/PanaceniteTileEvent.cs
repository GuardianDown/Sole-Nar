using System.Collections.Generic;
using SoleNar.UI;
using System;
using SoleNar.Player;
using System.Linq;
using SoleNar.Map;

namespace SoleNar.Events
{
    //TODO: REFACTIORING TILE EVENTS!
    public class PanaceniteTileEvent : TileEvent<PanaceniteEventData, IPanaceniteEventView>
    {
        private int _panacenitCounter;

        public override event Action onCompleted;

        public PanaceniteTileEvent(IPlayerMovement playerMovement,
            IPanaceniteEventView eventView, 
            IEnumerable<PanaceniteEventData> eventData,
            IEnumerable<IPlayerResource<int>> playerResources,
            IVisitedTilesData visitedTilesData) : base(playerMovement, eventData, eventView, playerResources, visitedTilesData)
        {

        }

        protected override void Subscribe()
        {
            _eventView.onInspect += Inspect;
            _eventView.onClose += EndEvent;
        }

        protected override void Unsubscribe()
        {
            _eventView.onInspect -= Inspect;
            _eventView.onClose -= EndEvent;
        }

        private void Inspect()
        {
            _eventView.SetEventText(_currentEventData.CollectTexts.ElementAt(_panacenitCounter));
            ++_panacenitCounter;
            ChangeResourcesValue(_currentEventData.ResourceID, 1);
            Move();
            onCompleted?.Invoke();
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
