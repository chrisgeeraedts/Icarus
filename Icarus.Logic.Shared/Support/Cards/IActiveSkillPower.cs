using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Support.Cards
{
    public interface IActiveSkillPower
    {
        BaseCard BaseCard { get; set; }
        int ActiveSkillTriggerCounter { get; set; }
        Guid UniquePowerId { get; }
        IGameWorldManager GameWorldManager { get; set; }
        bool ActivateAction();
        ActiveSkillTrigger ActiveSkillTrigger { get; set; }
    }
}