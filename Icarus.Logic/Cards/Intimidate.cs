using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Intimidate : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Intimidate()
        {
            UniqueCardId = new Guid("ee687027-d342-441b-8434-b919d2b8b85a");
            CardEffects.Add(CardEffect.AddWeakEnemy, new CardEffectValueObject(typeof(int), 1));
            CardColor = CardColor.Red;
            CardType = CardType.Power;
            CardUseType = CardUseType.Exhaust;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Intimidate";
            Description = "Apply 1 Weak to ALL enemies";
        }
    }
}