﻿using System;
using System.Collections.Generic;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Wound : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Wound()
        {
            UniqueCardId = new Guid("2f37f6d9-8b5e-4255-ac9a-a831fe8d0b9c");
            CardColor = CardColor.Curse;
            CardType = CardType.Status;
            CardUseType = CardUseType.Exhaust;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Wound";
            Description = "Wound";
        }

        public override bool CanUseOverridable(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            return false;
        }
    }
}