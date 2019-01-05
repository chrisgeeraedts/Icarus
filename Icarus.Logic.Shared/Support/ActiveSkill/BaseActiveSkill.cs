using System;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Utility;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Shared.Support.ActiveSkill
{
    public abstract class BaseActiveSkill : IActiveSkillPower
    {
        protected BaseActiveSkill(BaseCard baseCard)
        {
            BaseCard = baseCard;
        }
        public BaseCard BaseCard { get; set; }
        public int ActiveSkillTriggerCounter { get; set; }
        public ActiveSkillTrigger ActiveSkillTrigger { get; set; }
        public abstract Guid UniquePowerId { get; }
        public IGameWorldManager GameWorldManager { get; set; }
        public abstract bool ShouldTrigger(IGameWorldManager gameWorldManager);

        public bool ActivateAction()
        {
            if (ActiveSkillTriggerCounter > 100) // counter to block potential infinite recursion
            {
                ActiveSkillTriggerCounter = 0;
            }
            else
            {
                ActiveSkillTriggerCounter++;
                Logger.Log($"Triggering Active Skill Event: {BaseCard.Name}");
                if (!ShouldTrigger(GameWorldManager)) return false;
                ActionWhenTriggered(GameWorldManager);
                return true;
            }

            return false;
        }

        public abstract bool ActionWhenTriggered(IGameWorldManager gameWorldManager);
    }
}