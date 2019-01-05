using System;
using System.Collections.Generic;
using Icarus.Logic.Power;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.ActiveSkill;

namespace Icarus.Logic.ActiveSkill
{
    public class RageActiveSkill : BaseActiveSkill
    {

        public override Guid UniquePowerId => new Guid("e4deea2f-7144-41e4-85ad-404d37709a41");

        public override bool ShouldTrigger(IGameWorldManager gameWorldManager)
        {
            return true;
        }

        public override bool ActionWhenTriggered(IGameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.AddBlockSelf(3);
            return true;
        }
        public RageActiveSkill(BaseCard baseCard) : base(baseCard) { }
    }
}