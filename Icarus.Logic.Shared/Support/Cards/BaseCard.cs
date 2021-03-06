﻿using System;
using System.Collections.Generic;
using System.Linq;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Shared.Utility;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.World;

namespace Icarus.Logic
{
    public abstract class BaseCard : ICardTemplate
    {
        public BaseCard()
        {
            CardEffects = new Dictionary<CardEffect, CardEffectValueObject>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public CardType CardType { get; set; }
        public CardCostType CardCostType { get; set; }
        public Guid UniqueCardId { get; set; }
        public CardColor CardColor { get; set; }
        public CardUseType CardUseType { get; set; }
        public Dictionary<CardEffect, CardEffectValueObject> CardEffects { get; set; }
        public Type UpgradeTarget { get; set; }
        public CardRarity CardRarity { get; set; }
        public AfterTurnCountEvent AfterTurnCountEvent { get; set; }

        public bool ActivateEffects(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            foreach (var cardEffect in CardEffects)
            {
                gameWorldManager.CardEffectManager.ActivateEffect(cardEffect.Key, cardEffect.Value, targets, cardTargets, this);
            }
            return true;
        }

        public bool Use(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            if (CanUse(gameWorldManager, targets, cardTargets))
            {
                ActivateEffects(gameWorldManager, targets, cardTargets);
                var result = UseOverridable(gameWorldManager, targets, cardTargets);
                gameWorldManager.GameTurnManager.ActivateAvailablePowerTriggers(PowerTrigger.Always);

                if (this.CardType == CardType.Attack)
                {
                    gameWorldManager.GameTurnManager.ActivateActiveSkillCardsThisTurn(ActiveSkillTrigger.OnAttack);
                }
               
                return result;
            }
            return false;
        }
        public bool CanUse(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            var canBeUsed = CanUseOverridable(gameWorldManager, targets, cardTargets);
            Logger.Log($"Checking if card can be used: {canBeUsed}");
            return canBeUsed;
        }
        public int CalculateDamage(IGameWorldManager gameWorldManager, int baseDamage, IEnemyInstance target)
        {
            //TODO: actually calculate shit here
            var calculatedValue = CalculateDamageOverridable(gameWorldManager, baseDamage, target);
            Logger.Log($"Calculating actual damage: {calculatedValue} for target: {target.Name}({target.UniqueId})");
            return calculatedValue;
        }

        public int CalculateCost(IGameWorldManager gameWorldManager, int baseDamage, ICardInstance cardInstance)
        {
            //TODO: actually calculate shit here
            var calculatedValue = CalculateCostOverridable(gameWorldManager, cardInstance);
            Logger.Log($"Calculating actual cost: {calculatedValue} for card: {cardInstance.Name}({cardInstance.UniqueId})");
            return calculatedValue;
        }

        public virtual bool UseOverridable(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            // Do nothing
            return true;
        }
        public virtual bool CanUseOverridable(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            // Do nothing
            return true;
        }

        public virtual int CalculateDamageOverridable(IGameWorldManager gameWorldManager, int baseDamage, IEnemyInstance target)
        {
            //TODO: actually calculate shit here
            var calculatedValue = baseDamage;
            return calculatedValue;
        }

        public virtual int CalculateCostOverridable(IGameWorldManager gameWorldManager, ICardInstance cardInstance)
        {
            //TODO: actually calculate shit here

            // In case of CorruptionPower:
            if (CardType == CardType.Skill)
            {
                var hasCorruption = gameWorldManager.HeroManager.ActivePowerCards.Any(x => x.UniquePowerId == new Guid("05bbe85a-f7da-4555-a7cc-cc60bbc21bed"));
                if (hasCorruption)
                {
                    return 0;
                }
            }

            var calculatedCost = Cost;
            return calculatedCost;
        }
    }
}