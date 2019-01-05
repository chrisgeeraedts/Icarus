using System;
using Icarus.Logic.ActiveSkill;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class FlameBarrier : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public FlameBarrier()
        {
            UniqueCardId = new Guid("d1410e0bf75f4d19b788558ffbd12b89");
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(typeof(int), 12));
            CardEffects.Add(CardEffect.AddSkillThisTurn, new CardEffectValueObject(typeof(FlameBarrierActiveSkill), new FlameBarrierActiveSkill(this)
            {
                ActiveSkillTrigger = ActiveSkillTrigger.OnBeingAttacked
            }));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 2;
            Name = "Flame Barrier";
            Description = "Gain 12 Block. Whenever you are attacked this turn, deal 4 damage back";
        }
    }
}