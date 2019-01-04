using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Clash : BaseCard, ICardTemplate
    {
        public Clash()
        {
            UniqueCardId = new Guid("4ec7e5d8-9669-43eb-ba7d-a042e447c761");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 14, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Clash";
            Description = "Can only be played if every card in your hand is an attack, deal 14 damage";
        }

        public override bool CanUseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            foreach (var cardInHand in gameWorldManager.CardManager.Hand)
            {
                if (cardInHand.CardType != CardType.Attack)
                {
                    return false;
                }
            }
            return true;
        }
    }
}