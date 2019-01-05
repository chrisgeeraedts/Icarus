using System;
using System.Collections.Generic;
using Icarus.Logic.Support.World;

namespace Icarus.Logic
{
    public interface IEnemyInstance : IEnemyTemplate, ICountBase
    {
        Guid UniqueId { get; }
        int ActualHealth { get; set; }
        List<AfterTurnCountEvent> AfterTurnCountEvent { get; set; }
    }
}