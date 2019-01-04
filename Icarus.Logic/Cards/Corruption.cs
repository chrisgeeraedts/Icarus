using System;
using Icarus.Logic.Power;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Corruption : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Corruption()
        {
            UniqueCardId = new Guid("ac378a4d-5f5a-48e1-804a-1d6db98a8668");
            CardEffects.Add(CardEffect.AddPowerToHero, new CardEffectValueObject(typeof(CorruptionPower), new CorruptionPower(this) { PowerTrigger = PowerTrigger.Always }));
            CardColor = CardColor.Red;
            CardType = CardType.Power;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 3;
            Name = "Corruption";
            Description = "Skills cost 0. Whenever you play a Skill, Exhaust it.";
        }
    }
}