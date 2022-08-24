using SoleNar.Player;
using SoleNar.UI;
using System.Linq;
using System.Collections.Generic;
using Zenject;
using System;

namespace SoleNar.Events
{
    public class BattleEvent
    {
        private readonly BattleView _battleView;
        private readonly IDiceRoll _diceRoll;
        private readonly IPlayerResource<int> _playerHealth;
        private readonly IPlayerResource<int> _playerAttackStrength;
        private readonly IPlayerResource<int> _playerRepairKit;
        private readonly IPlayerResource<int> _playerTorpedo;

        private int _currentEnemyHealth;
        private int _enemyAttackStrenght;

        public event Action onBattleEnd;

        [Inject]
        public BattleEvent(BattleView battleView, IDiceRoll diceRoll, IEnumerable<IPlayerResource<int>> playerResources)
        {
            _battleView = battleView;
            _diceRoll = diceRoll;
            _playerHealth = playerResources.SingleOrDefault(resource => resource.ID == "Health");
            _playerAttackStrength = playerResources.SingleOrDefault(resource => resource.ID == "AttackStrenght");
            _playerRepairKit = playerResources.SingleOrDefault(resource => resource.ID == "RepairKit");
            _playerTorpedo = playerResources.SingleOrDefault(resource => resource.ID == "Torpedo");
        }

        public void StartBattle(EnemyData enemyData)
        {
            _battleView.SetEnemy(enemyData.EnemySprites);
            _battleView.SetEnemyHealth(enemyData.Health);
            _battleView.SetEnemyStrenght(enemyData.AttackStrenght);
            _battleView.Enable();
            _currentEnemyHealth = enemyData.Health;
            _enemyAttackStrenght = enemyData.AttackStrenght;
            Subscribe();
        }

        private void Subscribe()
        {
            _battleView.onAttack += Attack;
            _battleView.onRepair += Repair;
            _battleView.onTorpedo += Torpedo;
            _battleView.onClose += EndBattle;

        }

        private void Unsubscribe()
        {
            _battleView.onAttack -= Attack;
            _battleView.onRepair -= Repair;
            _battleView.onTorpedo -= Torpedo;
            _battleView.onClose -= EndBattle;

        }

        private void Attack()
        {
            int result = _diceRoll.GetResult();
            if(result < 3)
            {
                _playerHealth.AddValue(-_enemyAttackStrenght);
            }
            else
            {
                _currentEnemyHealth -= _playerAttackStrength.CurrentValue;
                _battleView.SetEnemyHealth(_currentEnemyHealth);
                if(_currentEnemyHealth <= 0)
                {
                    _battleView.EnableCloseButton();
                }
            }
            _battleView.SetDiceValue(result);
        }

        private void Repair()
        {
            if(_playerRepairKit.CurrentValue > 0)
            {
                _playerRepairKit.AddValue(-1);
                _playerHealth.AddValue(5);
            }
        }

        private void Torpedo()
        {
            if(_playerTorpedo.CurrentValue > 0)
            {
                _playerTorpedo.AddValue(-1);
                _currentEnemyHealth -= 5;
                _battleView.SetEnemyHealth(_currentEnemyHealth);
                if (_currentEnemyHealth <= 0)
                {
                    _battleView.EnableCloseButton();
                }
            }
        }

        private void EndBattle()
        {
            Unsubscribe();
            _battleView.Disable();
            _battleView.DisableCloseButton();
            onBattleEnd?.Invoke();
        }
    }
}
