using System;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class TwinStrike : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public TwinStrike()
        {
            UniqueCardId = new Guid("590f79c1-da0e-4d0a-8abf-fdf3498a10f6");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 5, HitTimes = 2}));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Twin Strike";
            Description = "Deal 5 damage twice";
        }
    }
}