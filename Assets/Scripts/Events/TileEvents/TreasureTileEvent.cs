using System.Collections.Generic;
using SoleNar.UI;
using System;
using SoleNar.Player;
using Zenject;
using System.Linq;
using SoleNar.Map;

namespace SoleNar.Events
{
    //TODO: REFACTIORING TILE EVENTS!
    public class TreasureTileEvent : TileEvent<TreasureEventData, IInspectEventView>
    {
        private readonly BattleEvent _battleEvent;

        public override event Action onCompleted;
        
        [Inject]
        public TreasureTileEvent(IEnumerable<TreasureEventData> treasureEventData,
            IInspectEventView eventView,
            IDiceRoll diceRoll,
            IPlayerMovement playerMovement,
            BattleEvent battleEvent,
            IEnumerable<IPlayerResource<int>> playerResources,
            IVisitedTilesData visitedTilesData) : base(playerMovement, treasureEventData, eventView, playerResources, visitedTilesData)
        {
            _battleEvent = battleEvent;
        }

        protected override void Subscribe()
        {
            _eventView.onInspect += Attack;
            _eventView.onIgnore += Retreat;
            _eventView.onClose += EndEvent;
        }

        protected override void Unsubscribe()
        {
            _eventView.onInspect -= Attack;
            _eventView.onIgnore -= Retreat;
            _eventView.onClose -= EndEvent;
        }

        private void Attack()
        {
            SetRandomText(_currentEventData.AttackTexts);
            Move();
            InitializeBattleView();
            onCompleted?.Invoke();
        }

        private void InitializeBattleView()
        {
            EnemyData enemyData = _currentEventData.EnemiesData.ElementAt(UnityEngine.Random.Range(0, _currentEventData.EnemiesData.Count()));
            _battleEvent.StartBattle(enemyData);
            _battleEvent.onBattleEnd += EndBattle;
        }

        private void Retreat() =>
            SetRandomText(_currentEventData.RetreatTexts);

        private void EndBattle()
        {
            _battleEvent.onBattleEnd -= EndBattle;
            SetRandomText(_currentEventData.IncreaseMaxHealthTexts);
        }
    }
}
