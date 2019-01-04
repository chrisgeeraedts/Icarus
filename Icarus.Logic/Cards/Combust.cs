using System;
using Icarus.Logic.Power;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Combust : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Combust()
        {
            UniqueCardId = new Guid("f508e591-987c-4bb4-8cfe-727d54e6bf84");
            CardEffects.Add(CardEffect.AddPowerToHero, new CardEffectValueObject(typeof(CombustPower), new CombustPower(this){PowerTrigger = PowerTrigger.EndOfPlayerTurn}));
            CardColor = CardColor.Red;
            CardType = CardType.Power;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Combust";
            Description = "At the end of your turn, lose 1 HP and deal 5 damage to ALL enemies.";
        }
    }
}