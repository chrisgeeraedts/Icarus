using System;
using Icarus.Logic.Shared.Support.ActiveSkill;

namespace Icarus.Logic.Shared.Events.Args
{
    public class SkillCardActivatedEventArgs : EventArgs
    {
        public BaseActiveSkill ActiveSkillCard { get; set; }
    }
}