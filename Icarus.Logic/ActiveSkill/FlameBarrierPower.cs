using System;
using Icarus.Logic.Managers;
using Icarus.Logic.Power;

namespace Icarus.Logic.ActiveSkill
{
    public class FlameBarrierActiveSkill : BaseActiveSkill
    {

        public override Guid UniquePowerId => new Guid("e422fd4ef3ba4a809e96182fe6a28219");

        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return true;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.AddBlockSelf(4);

            return true;
        }
        public FlameBarrierActiveSkill(BaseCard baseCard) : base(baseCard) { }
    }
}