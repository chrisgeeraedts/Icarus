using System;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class BurningPact : BaseCard, ICardTemplate
    {
        public BurningPact()
        {
            UniqueCardId = new Guid("7839238f-7bd0-4d49-8bcd-66302dc3e0bd");
            CardEffects.Add(CardEffect.ExhaustCard, new CardEffectValueObject(typeof(int), 1));
            CardEffects.Add(CardEffect.DrawCards, new CardEffectValueObject(typeof(int), 2));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Burning Pact";
            Description = "Exhaust 1 card. Draw 2 cards.";
        }
    }
}