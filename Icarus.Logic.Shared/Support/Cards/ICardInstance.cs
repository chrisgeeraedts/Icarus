using System;
using System.Collections.Generic;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic
{
    public interface ICardInstance
    {
        BaseCard BaseCard { get; set; }
        int ActualCost { get; set; }
        Guid UniqueId { get; }
        bool Use();
        bool Use(List<IEnemyInstance> targets, List<ICardInstance> cardtargets, bool? skipLog = false);
        int CalculateActualCost();
        Guid UniqueCardId { get; }
        string Name { get; }
        CardType CardType { get; }
    }

    // Used for filtering shuffle and draw actions to avoid a full list of filtered cards
    public interface IPlayableCardTemplate
    {

    }
}