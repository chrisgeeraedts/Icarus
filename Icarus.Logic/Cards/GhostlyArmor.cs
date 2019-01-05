using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class GhostlyArmor : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public GhostlyArmor()
        {
            UniqueCardId = new Guid("b901657f-683a-4545-ad9d-bedeae61212b");
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(typeof(int), 10));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Ghostly Armor";
            Description = "Gain 10 Block.";
        }
    }
}