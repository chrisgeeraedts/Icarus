using System;
using Icarus.Logic.Power;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Evolve : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Evolve()
        {
            UniqueCardId = new Guid("47d86ae7-c34c-4dcc-a845-a0e291d63ffa");
            CardEffects.Add(CardEffect.AddPowerToHero, new CardEffectValueObject(typeof(EvolvePower), new EvolvePower(this) { PowerTrigger = PowerTrigger.OnCardDraw }));
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