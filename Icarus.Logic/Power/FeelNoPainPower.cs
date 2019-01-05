using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.Power;

namespace Icarus.Logic.Power
{
    public class FeelNoPainPower : BasePower
    {
        public override Guid UniquePowerId => new Guid("963f937f-f6c1-4f5e-8fd1-b75412e3d443");
        public override bool ShouldTrigger(IGameWorldManager gameWorldManager)
        {
            return gameWorldManager.CardManager.LastCardExhausted != null && gameWorldManager.CardManager.LastCardExhausted.BaseCard.CardUseType == CardUseType.Exhaust;
        }

        public override bool ActionWhenTriggered(IGameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.AddBlockSelf(3);
            return true;
        }

        public FeelNoPainPower(BaseCard baseCard) : base(baseCard){}
    }
} 