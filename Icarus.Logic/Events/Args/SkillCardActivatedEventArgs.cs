using System;
using Icarus.Logic.ActiveSkill;

namespace Icarus.Logic.Events.Args
{
    public class SkillCardActivatedEventArgs : EventArgs
    {
        public BaseActiveSkill ActiveSkillCard { get; set; }
    }
}