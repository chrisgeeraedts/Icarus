using System;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class DefendPlus : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public DefendPlus()
        {
            UniqueCardId = new Guid("f50d89a8-c94a-4583-8877-254d1d7af693");
            var value = 7;
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(value.GetType(), value));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = typeof(DefendPlus2);
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Defend+";
            Description = "Gain 7 Block";
        }
    }
}