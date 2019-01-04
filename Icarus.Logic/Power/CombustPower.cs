using System;
using System.Collections.Generic;
using Icarus.Logic.Cards;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Power
{
    public class CombustPower : BasePower
    {

        public override Guid UniquePowerId => new Guid("3378461b-5094-46b8-a965-b31853c07da7");

        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return gameWorldManager.GameTurnManager.TurnType == TurnType.Player;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.LoseHealth(1);
            gameWorldManager.CardEffectManager.DamageTarget(new Null(), new DamageMultipleTimesEffect() { HitTimes = 1, DamageAmount = 5 }, gameWorldManager.EnemyManager.Enemies);

            return true;
        }
        public CombustPower(BaseCard baseCard) : base(baseCard) { }
    }

    public class FireBreathingPower : BasePower
    {

        public override Guid UniquePowerId => new Guid("c7931133cb00438d802fe65298fa9ed0");

        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return gameWorldManager.GameTurnManager.TurnType == TurnType.Player;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.DamageTarget(new Null(), new DamageMultipleTimesEffect() { HitTimes = 1, DamageAmount = 1 }, gameWorldManager.EnemyManager.Enemies);

            return true;
        }
        public FireBreathingPower(BaseCard baseCard) : base(baseCard) { }
    }
}