using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Power;
using Icarus.Logic.Support.Cards.Effects;

namespace Icarus.Logic.ActiveSkill
{
    public class RageActiveSkill : BaseActiveSkill
    {

        public override Guid UniquePowerId => new Guid("e4deea2f-7144-41e4-85ad-404d37709a41");

        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return true;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.AddBlockSelf(3);
            return true;
        }
        public RageActiveSkill(BaseCard baseCard) : base(baseCard) { }
    }
}