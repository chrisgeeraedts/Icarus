using System;
using System.Collections.Generic;
using Icarus.Logic;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.ModExample
{
    public class NewCard : BaseCard, IPlayableCardTemplate
    {
        public NewCard()
        {
            UniqueCardId = new Guid("764d2334-94d2-48fd-8219-07cb51e54324");
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(typeof(int), 50));
            CardColor = CardColor.Colorless;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Exhaust;
            UpgradeTarget = null;
            CardRarity = CardRarity.Mythic;
            Cost = 1;
            Name = "New Card";
            Description = "New Card from modded content";
        }

        public bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            return true;
        }

        public bool CanUseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            return true;
        }

        public int CalculateDamageOverridable(GameWorldManager gameWorldManager, int baseDamage, IEnemyInstance target)
        {
            return baseDamage;
        }

        public int CalculateCostOverridable(GameWorldManager gameWorldManager, ICardInstance cardInstance)
        {
            return Cost;
        }
    }
}