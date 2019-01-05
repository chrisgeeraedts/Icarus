using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class HeavyBlade : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public HeavyBlade()
        {
            UniqueCardId = new Guid("3c27f381-00a0-415a-97ab-1d18337bbfaf");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 14, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 2;
            Name = "Heavy Blade";
            Description = "Deal 14 damage. Strength affects this card 3 times.";
        }

        public override int CalculateDamageOverridable(IGameWorldManager gameWorldManager, int baseDamage, IEnemyInstance target)
        {
            return baseDamage + (gameWorldManager.HeroManager.StatusValues[StatusEffect.Strength] * 3);
        }
    }
}