using System;
using Icarus.Logic.Power;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class FireBreathing : BaseCard, ICardTemplate
    {
        public FireBreathing()
        {
            UniqueCardId = new Guid("97bda7e7-3f7e-467c-a3ca-4e5c0d0370cb");
            CardEffects.Add(CardEffect.AddPowerToHero, new CardEffectValueObject(typeof(FireBreathingPower), new FireBreathingPower(this) { PowerTrigger = PowerTrigger.EndOfPlayerTurn }));
            CardColor = CardColor.Red;
            CardType = CardType.Power;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Fire Breathing";
            Description = "At the end of your turn, deal 1 damage to all enemies for each Attack played this turn.";
        }
    }
}