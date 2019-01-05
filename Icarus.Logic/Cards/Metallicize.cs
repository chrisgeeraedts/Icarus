using System;
using Icarus.Logic.Power;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Metallicize : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Metallicize()
        {
            UniqueCardId = new Guid("20def8cd-9b13-4cf1-a717-98fcdfa94d13");
            CardEffects.Add(CardEffect.AddPowerToHero, new CardEffectValueObject(typeof(MetallicizePower), new MetallicizePower(this)
            {
                PowerTrigger = PowerTrigger.EndOfPlayerTurn
            }));
            CardColor = CardColor.Red;
            CardType = CardType.Power;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Metallicize";
            Description = "At the end of your turn, gain 3 Block";
        }
    }
}