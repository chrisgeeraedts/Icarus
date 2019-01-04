using System;
using Icarus.Logic.Power;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class FeelNoPain : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public FeelNoPain()
        {
            UniqueCardId = new Guid("97bda7e7-3f7e-467c-a3ca-4e5c0d0370cb");
            CardEffects.Add(CardEffect.AddPowerToHero, new CardEffectValueObject(typeof(FeelNoPainPower), new FeelNoPainPower(this) { PowerTrigger = PowerTrigger.OnCardExhaust }));
            CardColor = CardColor.Red;
            CardType = CardType.Power;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Evolve";
            Description = "Whenever you draw a Status card, draw 1 card.";
        }
    }
}