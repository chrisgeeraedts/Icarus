using System;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class BashPlus2 : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public BashPlus2()
        {
            UniqueCardId = new Guid("fa140a24-1d8a-435e-9380-f3f5630edcaf");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 10, HitTimes = 1 }));
            CardEffects.Add(CardEffect.AddVulnerableEnemy, new CardEffectValueObject(typeof(int), 3));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = typeof(DefendPlus);
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Bash++";
            Description = "Deal 10 damage and apply 3 vulnerable";
        }
    }
}