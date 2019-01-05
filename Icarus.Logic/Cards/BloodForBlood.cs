using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class BloodForBlood : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public BloodForBlood()
        {
            UniqueCardId = new Guid("c06ddf6a-e3c7-4dec-9da9-629b3b3d650e");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 18, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 4;
            Name = "Blood for Blood";
            Description = "Costs 1 less energy for each time you lose HP this combat. Deal 18 damage";
        }

        public override int CalculateCostOverridable(IGameWorldManager gameWorldManager, ICardInstance cardInstance)
        {
            var baseCost = base.CalculateCostOverridable(gameWorldManager, cardInstance);
            var newValue = Cost - (gameWorldManager.HeroManager.MetaInformation[MetaInformation.TimesPlayerGotAttacked] * 1);

            if (newValue > baseCost)
            {
                return baseCost;
            }
            return newValue >= 0 ? newValue : 0;
        }
    }
}