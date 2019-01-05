using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class DefendPlus2 : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public DefendPlus2()
        {
            UniqueCardId = new Guid("4e99a125-0815-412e-a112-b9088119d0b6");
            var value = 10;
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(value.GetType(), value));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Defend++";
            Description = "Gain 10 Block";
        }
    }
}