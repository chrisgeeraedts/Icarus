using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class WildStrike : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public WildStrike()
        {
            UniqueCardId = new Guid("590f79c1-da0e-4d0a-8abf-fdf3498a10f6");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 12, HitTimes = 1 }));
            CardEffects.Add(CardEffect.ShuffleCardIntoPile, new CardEffectValueObject(typeof(ShuffleCardIntoPileEffect), new ShuffleCardIntoPileEffect() { CardAmount = 1, ShuffleTargetPile = CardMovePoint.Deck, CardToShuffle = typeof(Wound) }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Wild Strike";
            Description = "Deal 12 damage. Shuffle a Wound into your draw pile";
        }
    }
}