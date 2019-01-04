using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class InfernalBlade : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public InfernalBlade()
        {
            UniqueCardId = new Guid("9ab2227e-68de-430d-8338-e70f88a50004");
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Exhaust;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Infernal Blade";
            Description = "Add a random Attack into your hand. It costs 0 this turn.";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            CardColor targetCardColor = CardColor.Any;
            CardType targetCardType = CardType.Attack;
            CardMovePoint targetCardMovePoint = CardMovePoint.Hand;
            gameWorldManager.CardManager.CreateRandomCard(targetCardColor, targetCardType, targetCardMovePoint, ShuffleFormat.Bottom);

            return true;
        }
    }
}