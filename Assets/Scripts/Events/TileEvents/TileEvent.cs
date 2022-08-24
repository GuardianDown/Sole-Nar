using SoleNar.Player;
using SoleNar.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SoleNar.Events
{
    //TODO: REFACTIORING TILE EVENTS!
    public abstract class TileEvent<DataType, ViewType> : ITileEvent 
        where DataType : TileEventData 
        where ViewType : ITileEventView
    {
        private readonly IPlayerMovement _playerMovement;
        private readonly IEnumerable<DataType> _eventData;
        private readonly IPlayerResource<int> _playerFuel;
        protected readonly IEnumerable<IPlayerResource<int>> _playerResources;
        protected readonly ViewType _eventView;

        private Vector3Int _currentTilePosition;
        protected DataType _currentEventData;

        public event Action onClosed;

        public abstract event Action onCompleted;

        public TileEvent(IPlayerMovement playerMovement, IEnumerable<DataType> eventData, 
            ViewType eventView, IEnumerable<IPlayerResource<int>> playerResources)
        {
            _playerMovement = playerMovement;
            _eventData = eventData;
            _eventView = eventView;
            _playerResources = playerResources;
            _playerFuel = playerResources.SingleOrDefault(resource => resource.ID == PlayerResourcesID.FuelID);
        }

        protected abstract void Subscribe();

        protected abstract void Unsubscribe();

        public virtual bool TryStartEvent(string tileID, Vector3Int tilePosition)
        {
            foreach (DataType data in _eventData)
            {
                if (data.ID == tileID)
                {
                    _currentEventData = data;
                    _currentTilePosition = tilePosition;
                    InitializeView();
                    Subscribe();
                    _eventView.Enable();
                    return true;
                }
            }

            return false;
        }

        protected virtual void EndEvent()
        {
            Unsubscribe();
            _eventView.ResetDiceView();
            onClosed?.Invoke();
        }

        protected void Move()
        {
            if (_currentEventData.IsPassable)
            {
                _playerMovement.Move(_currentTilePosition);
                _playerFuel.SubtractValue(_currentEventData.WasteOfFuel);
            }
        }

        protected void SetRandomText(IEnumerable<string> textsCollection) =>
            _eventView.SetEventText(textsCollection.ElementAt(UnityEngine.Random.Range(0, textsCollection.Count())));

        private void InitializeView()
        {
            SetRandomText(_currentEventData.IntroductionTexts);
            _eventView.SetTitle(_currentEventData.TitleText);
            _eventView.SetEventSprites(_currentEventData.TileSprites);
        }
    }
}
