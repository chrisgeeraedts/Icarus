using System;
using System.Linq;
using Icarus.Logic.Managers;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class PerfectedStrike : BaseCard, ICardTemplate
    {
        public PerfectedStrike()
        {
            UniqueCardId = new Guid("3c27f381-00a0-415a-97ab-1d18337bbfaf");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 6, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 2;
            Name = "Perfected Strike";
            Description = "Deal 6 damage. Deals additional damage for ALL your cards containing strike";
        }

        public override int CalculateDamageOverridable(GameWorldManager gameWorldManager, int baseDamage, IEnemyInstance target)
        {
            int cardCountWithStrike = 0;
            cardCountWithStrike += gameWorldManager.CardManager.DeckPile.Count(x => x.Name.ToLower().Contains("strike"));
            cardCountWithStrike += gameWorldManager.CardManager.ExhaustPile.Count(x => x.Name.ToLower().Contains("strike"));
            cardCountWithStrike += gameWorldManager.CardManager.Hand.Count(x => x.Name.ToLower().Contains("strike"));
            cardCountWithStrike += gameWorldManager.CardManager.DiscardPile.Count(x => x.Name.ToLower().Contains("strike"));
            return baseDamage + (cardCountWithStrike * 2);
        }
    }
}