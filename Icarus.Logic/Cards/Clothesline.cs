using System;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Clothesline : BaseCard, ICardTemplate
    {
        public Clothesline()
        {
            UniqueCardId = new Guid("61fe5e9a-5521-4c4b-9078-0c7ee0f4f89e");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 12, HitTimes = 1 }));
            CardEffects.Add(CardEffect.AddWeakEnemy, new CardEffectValueObject(typeof(int), 2));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            CardRarity = CardRarity.Normal;
            Cost = 2;
            Name = "Clothesline";
            Description = "Deal 12 damage and apply 2 weak";
        }
    }
}