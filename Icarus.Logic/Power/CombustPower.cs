using System;
using System.Collections.Generic;
using Icarus.Logic.Cards;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.Power;

namespace Icarus.Logic.Power
{
    public class CombustPower : BasePower
    {

        public override Guid UniquePowerId => new Guid("3378461b-5094-46b8-a965-b31853c07da7");

        public override bool ShouldTrigger(IGameWorldManager gameWorldManager)
        {
            return gameWorldManager.GameTurnManager.TurnType == TurnType.Player;
        }

        public override bool ActionWhenTriggered(IGameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.LoseHealth(1);
            gameWorldManager.CardEffectManager.DamageTarget(new Null(), new DamageMultipleTimesEffect() { HitTimes = 1, DamageAmount = 5 }, gameWorldManager.EnemyManager.Enemies);

            return true;
        }
        public CombustPower(BaseCard baseCard) : base(baseCard) { }
    }
}