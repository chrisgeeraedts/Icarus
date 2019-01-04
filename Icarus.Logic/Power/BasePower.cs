using System;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Power
{
    public abstract class BasePower : ICardPower
    {
        public BasePower(BaseCard baseCard)
        {
            BaseCard = baseCard;
        }
        public BaseCard BaseCard { get; set; }
        public int PowerTriggerCounter { get; set; }
        public PowerTrigger PowerTrigger { get; set; }
        public abstract Guid UniquePowerId { get; }
        public GameWorldManager GameWorldManager { get; set; }
        public abstract bool ShouldTrigger(GameWorldManager gameWorldManager);

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
                if (ShouldTrigger(GameWorldManager))
                {
                    ActionWhenTriggered(GameWorldManager);
                    return true;
                }
            }

            return false;
        }

        public abstract bool ActionWhenTriggered(GameWorldManager gameWorldManager);
    }
}