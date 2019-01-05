using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.Power;

namespace Icarus.Logic.Power
{
    public class MetallicizePower : BasePower
    {

        public override Guid UniquePowerId => new Guid("2fae8c82-4a4f-443f-896d-4bc3db65dc5f");

        public override bool ShouldTrigger(IGameWorldManager gameWorldManager)
        {
            return gameWorldManager.GameTurnManager.TurnType == TurnType.Player;
        }

        public override bool ActionWhenTriggered(IGameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.AddBlockSelf(3);

            return true;
        }
        public MetallicizePower(BaseCard baseCard) : base(baseCard) { }
    }
}