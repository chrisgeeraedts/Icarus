using System;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Support.Cards
{
    public interface IActiveSkillPower
    {
        BaseCard BaseCard { get; set; }
        int ActiveSkillTriggerCounter { get; set; }
        Guid UniquePowerId { get; }
        GameWorldManager GameWorldManager { get; set; }
        bool ActivateAction();
        ActiveSkillTrigger ActiveSkillTrigger { get; set; }
    }
}