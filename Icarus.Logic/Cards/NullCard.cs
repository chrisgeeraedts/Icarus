using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Null : BaseCard, ICardTemplate
    {
        public Null()
        {
            UniqueCardId = Guid.Empty;
            CardColor = CardColor.Colorless;
            CardType = CardType.Power;
            CardUseType = CardUseType.Default;
            CardRarity = CardRarity.Mythic;
            Cost = 999;
            Name = "Null";
            Description = "Null";
        }
    }
}