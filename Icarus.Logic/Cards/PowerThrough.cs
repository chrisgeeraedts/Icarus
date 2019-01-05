using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class PowerThrough : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public PowerThrough()
        {
            UniqueCardId = new Guid("b5cda2e1-12ff-4469-b9b9-7912c2aa5e3f");
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(typeof(int), 15));
            CardEffects.Add(CardEffect.ShuffleCardIntoPile, new CardEffectValueObject(typeof(ShuffleCardIntoPileEffect), new ShuffleCardIntoPileEffect()
            {
                CardAmount = 2, 
                CardToShuffle = typeof(Wound),
                ShuffleFormat = ShuffleFormat.Bottom,
                ShuffleTargetPile = CardMovePoint.Hand
            }));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Power Through";
            Description = "Add 2 Wounds into your hand. Gain 15 Block";
        }
    }
}