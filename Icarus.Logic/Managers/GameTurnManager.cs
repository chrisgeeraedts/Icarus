using System.Collections.Generic;
using Icarus.Logic.ActiveSkill;
using Icarus.Logic.Power;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Managers
{
    public class GameTurnManager : IManager
    {
        private readonly GameWorldManager _gameWorldManager;
        
        public GameTurnManager(GameWorldManager gameWorldManager)
        {
            _gameWorldManager = gameWorldManager;
        }

        public void Reset()
        {
            CanDrawCardsThisTurn = true;
            AfterTurnCountEvents = new List<AfterTurnCountEvent>();
            ActiveSkillCardsThisTurn = new List<BaseActiveSkill>();
            TurnType = TurnType.Player;
        }



        public List<BaseActiveSkill> ActiveSkillCardsThisTurn { get; set; }

        public TurnType TurnType { get; set; }
        public List<AfterTurnCountEvent> AfterTurnCountEvents { get; set; }
        public int TurnCount = 0;
        public bool CanDrawCardsThisTurn;
        public void StartNextTurn()
        {
            if (TurnType == TurnType.Player)
            {
                EndPlayerTurn();
                BeginEnemyTurn();
                TurnType = TurnType.Enemy;
            }
            else
            {
                EndEnemyTurn();
                BeginPlayerTurn();
                TurnType = TurnType.Player;
                TurnCount++;
            }
        }

        private void BeginPlayerTurn()
        {
            Logger.Log("# Beginning player turn");
            ActivateActiveSkillCardsThisTurn(ActiveSkillTrigger.EndOfPlayerTurn);
            ActivateAvailablePowerTriggers(PowerTrigger.Always);

            // Handle lingering actions
            foreach (var afterTurnCountEvent in AfterTurnCountEvents)
            {
                afterTurnCountEvent.CurrentTurnCount += 1;
                if (afterTurnCountEvent.CurrentTurnCount >= afterTurnCountEvent.MaxTurnCount)
                {
                    afterTurnCountEvent.AfterTurnCountAction(_gameWorldManager, afterTurnCountEvent.EnemyTargets, afterTurnCountEvent.CardTargets);
                }
            }

            // Move hand into discard pile
            List<ICardInstance> tempList = new List<ICardInstance>();
            tempList.AddRange(_gameWorldManager.CardManager.Hand);

            foreach (var card in tempList)
            {
                _gameWorldManager.CardManager.MoveCardBetweenPiles(card, CardMovePoint.Hand, CardMovePoint.DiscardPile);
            }

            // Draw new cards
            for (int i = 0; i < _gameWorldManager.CardManager.MaxHandSize - _gameWorldManager.CardManager.Hand.Count; i++)
            {
                _gameWorldManager.CardManager.DrawFromDeck();
            }
        }

       

        private void EndPlayerTurn()
        {
            Logger.Log("# Ending player turn");
            ActivateAvailablePowerTriggers(PowerTrigger.Always);
            ActivateAvailablePowerTriggers(PowerTrigger.EndOfPlayerTurn);

            _gameWorldManager.HeroManager.MetaInformation[MetaInformation.AttacksPlayedThisTurn] = 0;
            ActiveSkillCardsThisTurn = new List<BaseActiveSkill>();
        }

        private void BeginEnemyTurn()
        {
            ActivateAvailablePowerTriggers(PowerTrigger.Always);
            Logger.Log("# Beginning enemy turn");
            CanDrawCardsThisTurn = true;
        }

        private void EndEnemyTurn()
        {
            ActivateAvailablePowerTriggers(PowerTrigger.Always);
            Logger.Log("# Ending enemy turn");
        }

        public void ActivateAvailablePowerTriggers(PowerTrigger powerTrigger)
        {
            foreach (var heroManagerActivePowerCard in _gameWorldManager.HeroManager.ActivePowerCards)
            {
                if (heroManagerActivePowerCard.PowerTrigger == powerTrigger)
                {
                    if (heroManagerActivePowerCard.ActivateAction())
                    {
                        _gameWorldManager.EventManager.PowerActivated(heroManagerActivePowerCard);
                    }
                }
            }
        }

        private void ActivateActiveSkillCardsThisTurn(ActiveSkillTrigger activeSkillTrigger)
        {
            foreach (var activeSkillCard in ActiveSkillCardsThisTurn)
            {
                if (activeSkillCard.ActiveSkillTrigger == activeSkillTrigger)
                {
                    if (activeSkillCard.ActivateAction())
                    {
                        _gameWorldManager.EventManager.SkillCardActivated(activeSkillCard);
                    }
                }
            }
        }
    }
}