using System;
using Icarus.Logic.Cards;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Power
{
    public class FireBreathingPower : BasePower
    {

        public override Guid UniquePowerId => new Guid("95d8cf05-5532-4ac1-ba76-5b56019d9773");

        public override bool ShouldTrigger(GameWorldManager gameWorldManager)
        {
            return gameWorldManager.GameTurnManager.TurnType == TurnType.Player;
        }

        public override bool ActionWhenTriggered(GameWorldManager gameWorldManager)
        {
            gameWorldManager.CardEffectManager.DamageTarget(new Null(), new DamageMultipleTimesEffect() { HitTimes = gameWorldManager.HeroManager.MetaInformation[MetaInformation.TimesPlayerGotDamagedThisTurn], DamageAmount = 1 }, gameWorldManager.EnemyManager.Enemies);

            return true;
        }
        public FireBreathingPower(BaseCard baseCard) : base(baseCard) { }
    }
}