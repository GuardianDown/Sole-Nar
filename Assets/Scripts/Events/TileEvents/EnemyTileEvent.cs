using SoleNar.Player;
using SoleNar.UI;
using System;
using System.Collections.Generic;
using Zenject;

namespace SoleNar.Events
{
    internal sealed class EnemyTileEvent : TileEvent<EnemyEventData, IEnemyEventView>
    {
        private readonly IDiceRoll _diceRoll;

        public override event Action onCompleted;
        public override event Action onIgnored;

        [Inject]
        public EnemyTileEvent(IEnumerable<EnemyEventData> battleEventData,
            IEnemyEventView battleEventView,
            IDiceRoll diceRoll,
            IPlayerMovement playerMovement) : base(playerMovement, battleEventData, battleEventView) => 
            _diceRoll = diceRoll;

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
            Move();
            onCompleted?.Invoke();
        }

        private void Stealth()
        {
            int result = _diceRoll.GetResult();
            SetRandomText(result < 3 ? _currentEventData.StrealthFailedTexts : _currentEventData.StealthSuccessTexts);
            _eventView.SetDiceValue(result);
            Move();
            onIgnored.Invoke();
        }

        private void Retreat() => 
            SetRandomText(_currentEventData.RetreatTexts);
    }
}
