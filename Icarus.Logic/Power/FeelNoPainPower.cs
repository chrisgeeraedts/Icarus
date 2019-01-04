using System;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Power
{
    public class FeelNoPainPower : BasePower
    {
        public override Guid UniquePowerId => new Guid("963f937f-f6c1-4f5e-8fd1-b75412e3d443");
        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return gameWorldManager.CardManager.LastCardExhausted != null && gameWorldManager.CardManager.LastCardExhausted.CardUseType == CardUseType.Exhaust;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.AddBlockSelf(3);
            return true;
        }

        public FeelNoPainPower(BaseCard baseCard) : base(baseCard){}
    }
} 