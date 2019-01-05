using System;
using Icarus.Logic.Cards;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;
using Icarus.Logic.Support.Power;

namespace Icarus.Logic.Power
{
    public class FireBreathingPower : BasePower
    {

        public override Guid UniquePowerId => new Guid("95d8cf05-5532-4ac1-ba76-5b56019d9773");

        public override bool ShouldTrigger(IGameWorldManager gameWorldManager)
        {
            return gameWorldManager.GameTurnManager.TurnType == TurnType.Player;
        }

        public override bool ActionWhenTriggered(IGameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.DamageTarget(new Null(), new DamageMultipleTimesEffect() { HitTimes = gameWorldManager.HeroManager.MetaInformation[MetaInformation.TimesPlayerGotDamagedThisTurn], DamageAmount = 1 }, gameWorldManager.EnemyManager.Enemies);

            return true;
        }
        public FireBreathingPower(BaseCard baseCard) : base(baseCard) { }
    }
}