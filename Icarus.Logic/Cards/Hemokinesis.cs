using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Hemokinesis : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Hemokinesis()
        {
            UniqueCardId = new Guid("9ab2227e-68de-430d-8338-e70f88a50004");
            CardEffects.Add(CardEffect.LoseHealth, new CardEffectValueObject(typeof(int), 3));
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 14, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Hemokinesis";
            Description = "Lose 3 HP. Deal 14 damage.";
        }
    }
}