using System;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Thunderclap : BaseCard, ICardTemplate
    {
        public Thunderclap()
        {
            UniqueCardId = new Guid("66aa58c6-c01f-48d3-afed-cafb94e52267");
            CardEffects.Add(CardEffect.DamageAllTargets, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 4, HitTimes = 1 }));
            CardEffects.Add(CardEffect.AddVulnerableEnemy, new CardEffectValueObject(typeof(int), 1));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Thunderclap";
            Description = "Deal 4 damage and apply 1 Vulnerable to ALL enemies";
        }
    }
}