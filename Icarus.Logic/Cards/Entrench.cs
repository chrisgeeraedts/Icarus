using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Entrench : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Entrench()
        {
            UniqueCardId = new Guid("47d86ae7-c34c-4dcc-a845-a0e291d63ffa");
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 2;
            Name = "Entrench";
            Description = "Double your Block.";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            gameWorldManager.StatusValues[StatusEffect.Block] = gameWorldManager.StatusValues[StatusEffect.Block] * 2;
            return true;
        }
    }
}