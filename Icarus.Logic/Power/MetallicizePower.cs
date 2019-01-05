using System;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Power
{
    public class MetallicizePower : BasePower
    {

        public override Guid UniquePowerId => new Guid("2fae8c82-4a4f-443f-896d-4bc3db65dc5f");

        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return gameWorldManager.GameTurnManager.TurnType == TurnType.Player;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.AddBlockSelf(3);

            return true;
        }
        public MetallicizePower(BaseCard baseCard) : base(baseCard) { }
    }
}