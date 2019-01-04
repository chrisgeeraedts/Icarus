using System;
using System.Collections.Generic;
using System.Linq;
using Icarus.Logic.Cards;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Power
{
    public class CorruptionPower : BasePower
    {
        public override Guid UniquePowerId => new Guid("05bbe85a-f7da-4555-a7cc-cc60bbc21bed");
        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return true;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            foreach (var cardInstance in gameWorldManager.CardManager.Hand.Where(x => x.CardType == CardType.Skill))
            {
                cardInstance.ActualCost = 0;
                cardInstance.CardUseType = CardUseType.Exhaust;
            }
            foreach (var cardInstance in gameWorldManager.CardManager.DeckPile.Where(x => x.CardType == CardType.Skill))
            {
                cardInstance.ActualCost = 0;
                cardInstance.CardUseType = CardUseType.Exhaust;
            }
            foreach (var cardInstance in gameWorldManager.CardManager.DiscardPile.Where(x => x.CardType == CardType.Skill))
            {
                cardInstance.ActualCost = 0;
                cardInstance.CardUseType = CardUseType.Exhaust;
            }
            foreach (var cardInstance in gameWorldManager.CardManager.ExhaustPile.Where(x => x.CardType == CardType.Skill))
            {
                cardInstance.ActualCost = 0;
                cardInstance.CardUseType = CardUseType.Exhaust;
            }
            return true;
        }

        public CorruptionPower(BaseCard baseCard) : base(baseCard){}
    }
}