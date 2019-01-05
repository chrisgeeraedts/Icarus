using System;
using Icarus.Logic.ActiveSkill;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Rage : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Rage()
        {
            UniqueCardId = new Guid("d1410e0bf75f4d19b788558ffbd12b89");
            CardEffects.Add(CardEffect.AddSkillThisTurn, new CardEffectValueObject(typeof(RageActiveSkill), new RageActiveSkill(this)
            {
                ActiveSkillTrigger = ActiveSkillTrigger.OnAttack
            }));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Rage";
            Description = "Whenever you play an attack this turn, gain 3 block";
        }
    }
}