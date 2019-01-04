using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class BattleTrance : BaseCard, ICardTemplate
    {
        public BattleTrance()
        {
            UniqueCardId = new Guid("c06ddf6a-e3c7-4dec-9da9-629b3b3d650e");
            CardEffects.Add(CardEffect.DrawCards, new CardEffectValueObject(typeof(int), 3));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Battle Trance";
            Description = "Draw 3 cards. You cannot draw additional cards this turn";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            gameWorldManager.GameTurnManager.CanDrawCardsThisTurn = false;
            return true;
        }

        public override bool CanUseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            return gameWorldManager.GameTurnManager.CanDrawCardsThisTurn;
        }
    }
}