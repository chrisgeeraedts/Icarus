using System;
using System.Collections.Generic;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.ActiveSkill;
using Icarus.Logic.Shared.Support.Cards.Effects;

namespace Icarus.Logic.ActiveSkill
{
    public class FlameBarrierActiveSkill : BaseActiveSkill
    {

        public override Guid UniquePowerId => new Guid("46ea8216-c4b1-46aa-b4fb-ed8ec25cd532");

        public override bool ShouldTrigger(IGameWorldManager gameWorldManager)
        {
            return true;
        }

        public override bool ActionWhenTriggered(IGameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.DamageTarget(BaseCard, new DamageMultipleTimesEffect()
            {
                DamageAmount = 4,
                HitTimes = 1
            }, new List<IEnemyInstance>()
            {
                gameWorldManager.EnemyManager.ActiveEnemyInstance
            });

            return true;
        }
        public FlameBarrierActiveSkill(BaseCard baseCard) : base(baseCard) { }
    }
}