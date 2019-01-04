using System;
using System.Collections.Generic;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class PommelStrike : BaseCard, ICardTemplate
    {
        public PommelStrike()
        {
            UniqueCardId = new Guid("3c27f381-00a0-415a-97ab-1d18337bbfaf");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 9, HitTimes = 1 }));
            CardEffects.Add(CardEffect.DrawCards, new CardEffectValueObject(typeof(int), 1));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Pommel Strike";
            Description = "Deal 9 damage and draw 1 card.";
        }
    }
}