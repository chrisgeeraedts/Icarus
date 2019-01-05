using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Utility;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.World;

namespace Icarus.Logic.Support.Power
{
    public abstract class BasePower : ICardPower
    {
        protected BasePower(BaseCard baseCard)
        {
            BaseCard = baseCard;
        }
        public BaseCard BaseCard { get; set; }
        public int PowerTriggerCounter { get; set; }
        public PowerTrigger PowerTrigger { get; set; }
        public abstract Guid UniquePowerId { get; }
        public IGameWorldManager GameWorldManager { get; set; }
        public abstract bool ShouldTrigger(IGameWorldManager gameWorldManager);

        public bool ActivateAction()
        {
            if (PowerTriggerCounter > 100) // counter to block potential infinite recursion
            {
                PowerTriggerCounter = 0;
            }
            else
            {
                PowerTriggerCounter++;
                Logger.Log($"Triggering Power Event: {BaseCard.Name}");
                if (!ShouldTrigger(GameWorldManager)) return false;
                ActionWhenTriggered(GameWorldManager);
                return true;
            }

            return false;
        }

        public abstract bool ActionWhenTriggered(IGameWorldManager gameWorldManagerWorldManager);
    }
}