using System;
using System.Collections.Generic;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;

namespace Icarus.Logic
{
    public class AfterTurnCountEvent
    {
        public int MaxTurnCount { get; set; }
        public int CurrentTurnCount { get; set; }
        public Action<IGameWorldManager, List<IEnemyInstance>, List<ICardInstance>> AfterTurnCountAction { get; set; }
        public List<IEnemyInstance> EnemyTargets { get; set; }
        public List<ICardInstance> CardTargets { get; set; }
    }
}