using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Support.Cards
{
    public class CardInstance : ICardInstance
    {
        BaseCard cardInstance;
        public Type CardBase { get; set; }
        GameWorldManager GameWorldManager { get; set; }

        public Guid UniqueId { get; }

        public CardInstance(Type cardBase, GameWorldManager gameWorldManager)
        {
            UniqueId = Guid.NewGuid();
            CardBase = cardBase;
            GameWorldManager = gameWorldManager;
            cardInstance = (Activator.CreateInstance(CardBase) as BaseCard);
            ActualCost = CalculateActualCost();
            CardUseType = cardInstance.CardUseType;
        }

        private int _actualCost;
        public int ActualCost
        {
            get { return _actualCost; }
            set { _actualCost = value; }
        }

        public string Name => cardInstance.Name;
        public string Description => cardInstance.Description;
        public int Cost => cardInstance.Cost;

        public CardType CardType => cardInstance.CardType;
        public CardCostType CardCostType => cardInstance.CardCostType;

        public CardColor CardColor => cardInstance.CardColor;

        private CardUseType _cardUseType;

        public CardUseType CardUseType
        {
            get { return _cardUseType; }
            set { _cardUseType = value; }
        }

        public Type UpgradeTarget => cardInstance.UpgradeTarget;

        public Guid UniqueCardId => cardInstance.UniqueCardId;

        public CardRarity CardRarity => cardInstance.CardRarity;

        public int CalculateActualCost()
        {

            ActualCost = cardInstance.CalculateCostOverridable(GameWorldManager, this);

            Logger.Log($"Calculating actual cost for: {this.Name} ({this.UniqueId}) - now costs: {ActualCost}");

            //TODO actually do some proper calculation here
            return cardInstance.Cost;
        }

        private CardMovePoint DetermineCardMovePoint()
        {
            switch (CardUseType)
            {
                case CardUseType.Default:
                    return CardMovePoint.DiscardPile;
                case CardUseType.Exhaust:
                    return CardMovePoint.ExhaustPile;
                default:
                    throw new NotImplementedException();
            }
        }

        public bool Use()
        {
            Logger.Log($"! Card activation: {this.Name} ({this.UniqueId})");
            ActualCost = CalculateActualCost();
            if (GameWorldManager.HeroManager.CurrentEnergyCount >= ActualCost)
            {
                if (Use(new List<IEnemyInstance>(), new List<ICardInstance>(), true))
                {
                    if (CardType == CardType.Attack)
                    {
                        GameWorldManager.HeroManager.MetaInformation[MetaInformation.AttacksPlayedThisTurn]++;
                    }
                    if (CardType == CardType.Skill)
                    {
                        GameWorldManager.HeroManager.MetaInformation[MetaInformation.SkillsPlayedThisTurn]++;
                    }
                    if (CardType == CardType.Status)
                    {
                        GameWorldManager.HeroManager.MetaInformation[MetaInformation.StatusPlayedThisTurn]++;
                    }
                    if (CardType == CardType.Power)
                    {
                        GameWorldManager.HeroManager.MetaInformation[MetaInformation.PowersPlayedThisTurn]++;
                    }
                    if (CardType == CardType.Curse)
                    {
                        GameWorldManager.HeroManager.MetaInformation[MetaInformation.CursesPlayedThisTurn]++;
                    }
                    GameWorldManager.HeroManager.SpendEnergy(ActualCost);
                    GameWorldManager.CardManager.MoveCardBetweenPiles(this, CardMovePoint.Hand, DetermineCardMovePoint());
                    return true;
                }
            }            

            return false;
        }

        public bool Use(List<IEnemyInstance> targets, List<ICardInstance> cardTargets, bool? skipLog = false)
        {
            if (skipLog.HasValue && !skipLog.Value)
            {
                Logger.Log($"! Card activation: {this.Name} ({this.UniqueId})");
            }

            if (GameWorldManager.HeroManager.CurrentEnergyCount >= ActualCost)
            {
                if ((cardInstance as BaseCard).Use(GameWorldManager, targets, cardTargets))
                {
                    GameWorldManager.HeroManager.SpendEnergy(ActualCost);
                    GameWorldManager.CardManager.MoveCardBetweenPiles(this, CardMovePoint.Hand, DetermineCardMovePoint());

                    if (this.CardUseType == CardUseType.Exhaust)
                    {
                        GameWorldManager.CardManager.LastCardExhausted = this;
                    }
                    else if (this.CardUseType == CardUseType.Default)
                    {
                        GameWorldManager.CardManager.LastCardExhausted = this;
                    }

                    GameWorldManager.EventManager.CardUsed(this);
                    return true;
                }
            }

            return false;
        }
    }
}