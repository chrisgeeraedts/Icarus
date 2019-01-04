using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Dropkick : BaseCard, ICardTemplate
    {
        public Dropkick()
        {
            UniqueCardId = new Guid("37755ad4-a6d6-446a-b0f4-2736c8e45c74");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 5, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Dropkick";
            Description = "Deal 5 damage. If the enemy has Vulnerable, gain 1 Energy and draw 1 card";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            foreach (var target in targets)
            {
                if (target.StatusValues[StatusEffect.Vulnerable] > 0)
                {
                    gameWorldManager.HeroManager.CurrentEnergyCount += 1;
                    gameWorldManager.CardManager.DrawFromDeck();
                }
            }

            return true;
        }
    }
}