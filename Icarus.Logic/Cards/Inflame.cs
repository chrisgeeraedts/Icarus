using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Inflame : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Inflame()
        {
            UniqueCardId = new Guid("48002444-bad6-4b18-8b2c-0c92fe675758");
            CardEffects.Add(CardEffect.AddStrengthSelf, new CardEffectValueObject(typeof(int), 2));
            CardColor = CardColor.Red;
            CardType = CardType.Power;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Inflame";
            Description = "Gain 2 Strength";
        }
    }
}