using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Flex : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Flex()
        {
            UniqueCardId = new Guid("d3a82d3b-12a6-478d-8ab2-27c51449d5a0");
            CardEffects.Add(CardEffect.AddStrengthSelf, new CardEffectValueObject(typeof(int), 2));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Flex";
            Description = "Gain 2 Strength. At the end of this turn, lose 2 strength.";
            AfterTurnCountEvent = new AfterTurnCountEvent()
            {
                MaxTurnCount = 1,
                CurrentTurnCount = 1,
                AfterTurnCountAction = AfterTurnCountEventOverridable
            };
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            this.AfterTurnCountEvent.CardTargets = cardTargets;
            this.AfterTurnCountEvent.EnemyTargets = targets;
            gameWorldManager.GameTurnManager.AfterTurnCountEvents.Add(this.AfterTurnCountEvent);
            return true;
        }

        public void AfterTurnCountEventOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            gameWorldManager.StatusValues[StatusEffect.Strength] = gameWorldManager.StatusValues[StatusEffect.Strength] - 2;
        }
    }
}