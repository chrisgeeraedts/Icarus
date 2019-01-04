using System;
using System.Collections.Generic;

namespace Icarus.Logic.Enemies
{
    public class Enemy_Rat : BaseEnemy, IEnemyInstance
    {
        public Enemy_Rat()
        {
            UniqueId = Guid.NewGuid();
            Reset();
        }
        public override string Name => "Rat";
        public override int BaseMaxHealth => 12;

        public Guid UniqueId { get; }
        public List<AfterTurnCountEvent> AfterTurnCountEvent { get; set; }
    }
}