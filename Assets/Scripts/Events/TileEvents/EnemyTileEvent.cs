using SoleNar.Player;
using SoleNar.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace SoleNar.Events
{
    //TODO: REFACTIORING TILE EVENTS!
    internal sealed class EnemyTileEvent : TileEvent<EnemyEventData, IEnemyEventView>
    {
        private readonly IDiceRoll _diceRoll;
        private readonly BattleEvent _battleEvent;
        private readonly IPlayerResource<int> _playerStealth;

        public override event Action onCompleted;

        [Inject]
        public EnemyTileEvent(IEnumerable<EnemyEventData> battleEventData,
            IEnemyEventView battleEventView,
            IDiceRoll diceRoll,
            IPlayerMovement playerMovement,
            BattleEvent battleEvent,
            IEnumerable<IPlayerResource<int>> playerResources) : base(playerMovement, battleEventData, battleEventView, playerResources)
        {
            _diceRoll = diceRoll;
            _battleEvent = battleEvent;
            _playerStealth = _playerResources.SingleOrDefault(resource => resource.ID == PlayerResourcesID.StealthID);
        }

        protected override void Subscribe()
        {
            _eventView.onAttack += Attack;
            _eventView.onStealth += Stealth;
            _eventView.onRetreat += Retreat;
            _eventView.onClose += EndEvent;
        }

        protected override void Unsubscribe()
        {
            _eventView.onAttack -= Attack;
            _eventView.onStealth -= Stealth;
            _eventView.onRetreat -= Retreat;
            _eventView.onClose -= EndEvent;
        }

        private void Attack()
        {
            SetRandomText(_currentEventData.AttackTexts);
            InitializeBattleView();
            Move();
            onCompleted?.Invoke();
        }

        private void InitializeBattleView()
        {
            EnemyData enemyData = _currentEventData.EnemiesData
                .ElementAt(UnityEngine.Random.Range(0, _currentEventData.EnemiesData.Count()));
            _battleEvent.StartBattle(enemyData);
            _battleEvent.onBattleEnd += EndBattle;
        }

        private void Stealth()
        {
            int result = _diceRoll.GetResult();
            if(result > _diceRoll.MaxValue - _playerStealth.CurrentValue)
            {
                
                SetRandomText(_currentEventData.StealthSuccessTexts);
                _eventView.SetEndEventState();
                Move();
            }
            else
            {
                SetRandomText(_currentEventData.StrealthFailedTexts);
                _eventView.SetStealthFailedState();
            }
            _eventView.SetDiceValue(result);
        }

        private void Retreat() => 
            SetRandomText(_currentEventData.RetreatTexts);

        private void EndBattle()
        {
            _battleEvent.onBattleEnd -= EndBattle;
            SetRandomText(_currentEventData.BattleWinTexts);
            _eventView.SetEndEventState();
        }
    }
}
