using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Cleave : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Cleave()
        {
            UniqueCardId = new Guid("989f31e1-9702-433f-9a72-c5ec34dd5fca");
            CardEffects.Add(CardEffect.DamageAllTargets, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 8, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Cleave";
            Description = "Deal 8 damage to ALL enemies";
        }
    }
}