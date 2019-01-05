using System;
using System.Collections.Generic;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards;
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

        public override bool UseOverridable(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            return gameWorldManager.CardEffectManager.AddBlockSelf(
                gameWorldManager.HeroManager.StatusValues[StatusEffect.Block]);
        }
    }
}