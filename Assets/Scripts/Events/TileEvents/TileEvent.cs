using SoleNar.Player;
using SoleNar.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SoleNar.Events
{
    public abstract class TileEvent<DataType, ViewType> : ITileEvent 
        where DataType : TileEventData 
        where ViewType : ITileEventView
    {
        private readonly IPlayerMovement _playerMovement;
        private readonly IEnumerable<DataType> _eventData;
        protected readonly ViewType _eventView;

        private Vector3Int _currentTilePosition;
        protected DataType _currentEventData;

        public abstract event Action onCompleted;
        public abstract event Action onIgnored;

        public TileEvent(IPlayerMovement playerMovement, IEnumerable<DataType> eventData, ViewType eventView)
        {
            _playerMovement = playerMovement;
            _eventData = eventData;
            _eventView = eventView;
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
        }

        protected void Move()
        {
            if (_currentEventData.IsPassable)
                _playerMovement.Move(_currentTilePosition);
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
