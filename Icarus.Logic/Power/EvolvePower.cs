using System;
using System.Collections.Generic;
using System.Linq;
using Icarus.Logic.Cards;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Power
{
    public class EvolvePower : BasePower
    {
        public override Guid UniquePowerId => new Guid("ffc521ad-dd8d-40b9-869d-f9f90923a408");
        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return gameWorldManager.CardManager.LastCardPick != null && gameWorldManager.CardManager.LastCardPick.CardType == CardType.Status;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardManager.DrawFromDeck();

            return true;
        }

        public EvolvePower(BaseCard baseCard) : base(baseCard) { }
    }
}