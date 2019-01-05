using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Defend : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Defend()
        {
            UniqueCardId = new Guid("c704e77b-2208-435c-b2ef-83b557b2aa0c");
            var value = 5;
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(value.GetType(), value));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = typeof(DefendPlus);
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Defend";
            Description = "Gain 5 Block";
        }
    }
}