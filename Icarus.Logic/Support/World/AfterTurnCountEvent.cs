using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;

namespace Icarus.Logic
{
    public class AfterTurnCountEvent
    {
        public int MaxTurnCount { get; set; }
        public int CurrentTurnCount { get; set; }
        public Action<GameWorldManager, List<IEnemyInstance>, List<ICardInstance>> AfterTurnCountAction { get; set; }
        public List<IEnemyInstance> EnemyTargets { get; internal set; }
        public List<ICardInstance> CardTargets { get; internal set; }
    }
}