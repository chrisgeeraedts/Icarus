using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Utility;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.World;

namespace Icarus.Logic.Support.Cards
{
    public class CardInstance : ICardInstance
    {
        public BaseCard BaseCard { get; set; }
        IGameWorldManager GameWorldManager { get; set; }

        public Guid UniqueId { get; }

        public CardInstance(BaseCard baseCard, IGameWorldManager gameWorldManager)
        {
            UniqueId = Guid.NewGuid();
            BaseCard = baseCard;
            GameWorldManager = gameWorldManager;
            ActualCost = CalculateActualCost();
            CardUseType = BaseCard.CardUseType;
        }

        private int _actualCost;
        public int ActualCost
        {
            get { return _actualCost; }
            set { _actualCost = value; }
        }

        public string Name => BaseCard.Name;
        public string Description => BaseCard.Description;
        public int Cost => BaseCard.Cost;

        public CardType CardType => BaseCard.CardType;
        public CardCostType CardCostType => BaseCard.CardCostType;

        public CardColor CardColor => BaseCard.CardColor;

        private CardUseType _cardUseType;

        public CardUseType CardUseType
        {
            get { return _cardUseType; }
            set { _cardUseType = value; }
        }

        public Type UpgradeTarget => BaseCard.UpgradeTarget;

        public Guid UniqueCardId => BaseCard.UniqueCardId;

        public CardRarity CardRarity => BaseCard.CardRarity;

        public int CalculateActualCost()
        {

            ActualCost = BaseCard.CalculateCostOverridable(GameWorldManager, this);

            Logger.Log($"Calculating actual cost for: {this.Name} ({this.UniqueId}) - now costs: {ActualCost}");

            //TODO actually do some proper calculation here
            return BaseCard.Cost;
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
                if (BaseCard.Use(GameWorldManager, targets, cardTargets))
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