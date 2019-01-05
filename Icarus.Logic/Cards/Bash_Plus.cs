using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class BashPlus : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public BashPlus()
        {
            UniqueCardId = new Guid("fa140a24-1d8a-435e-9380-f3f5630edcaf");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 8, HitTimes = 1 }));
            CardEffects.Add(CardEffect.AddVulnerableEnemy, new CardEffectValueObject(typeof(int), 2));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = typeof(DefendPlus);
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Bash+";
            Description = "Deal 8 damage and apply 2 vulnerable";
        }
    }
}