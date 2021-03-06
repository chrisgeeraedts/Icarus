﻿using System;
using System.Collections.Generic;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class DuelWield : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public DuelWield()
        {
            UniqueCardId = new Guid("ad0c4489-1550-4c44-acdf-7250ef404588");
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Duel Wield";
            Description = "Choose an Attack or Power card. Add a copy of that card into your hand";
        }

        public override bool UseOverridable(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            foreach (var cardTarget in cardTargets)
            {
                CardInstance newCard = new CardInstance(cardTarget.BaseCard, gameWorldManager);
                gameWorldManager.CardManager.Hand.Add(newCard);
            }
            return true;
        }
    }
}