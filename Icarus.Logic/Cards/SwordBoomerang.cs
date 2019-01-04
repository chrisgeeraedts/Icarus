using System;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class SwordBoomerang : BaseCard, ICardTemplate
    {
        public SwordBoomerang()
        {
            UniqueCardId = new Guid("0963394e-b1e2-4147-ab10-9f2589829e7f");
            CardEffects.Add(CardEffect.DamageRandomTargets, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect() {DamageAmount = 3, HitTimes = 3}));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Sword Boomerang";
            Description = "Deal 3 damage to a random enemy 3 times";
        }
    }
}