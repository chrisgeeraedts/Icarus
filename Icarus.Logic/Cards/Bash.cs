using System;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Bash : BaseCard, ICardTemplate
    {
        public Bash()
        {
            UniqueCardId = new Guid("f260fce1-345e-4aa9-88b4-c4af0d0104d0");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 8, HitTimes = 1 }));
            CardEffects.Add(CardEffect.AddVulnerableEnemy, new CardEffectValueObject(typeof(int), 2));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = typeof(BashPlus);
            CardRarity = CardRarity.Normal;
            Cost = 2;
            Name = "Bash";
            Description = "Deal 8 damage and apply 2 vulnerable";
        }
    }
}