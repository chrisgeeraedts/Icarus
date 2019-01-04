using System;
using System.Collections.Generic;

namespace Icarus.Logic
{
    public interface ICardInstance : ICardTemplate
    {
        Type CardBase { get; set; }
        int ActualCost { get; set; }
        Guid UniqueId { get; }
        bool Use();
        bool Use(List<IEnemyInstance> targets, List<ICardInstance> cardtargets, bool? skipLog = false);
        int CalculateActualCost();
    }
}