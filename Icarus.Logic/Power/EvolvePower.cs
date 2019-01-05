using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.Power;

namespace Icarus.Logic.Power
{
    public class EvolvePower : BasePower
    {
        public override Guid UniquePowerId => new Guid("ffc521ad-dd8d-40b9-869d-f9f90923a408");
        public override bool ShouldTrigger(IGameWorldManager gameWorldManager)
        {
            return gameWorldManager.CardManager.LastCardPick != null && gameWorldManager.CardManager.LastCardPick.CardType == CardType.Status;
        }

        public override bool ActionWhenTriggered(IGameWorldManager gameWorldManager)
        {
            gameWorldManager.CardManager.DrawFromDeck();

            return true;
        }

        public EvolvePower(BaseCard baseCard) : base(baseCard) { }
    }
}