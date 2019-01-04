using System;
using System.Collections.Generic;

namespace Icarus.Logic.Enemies
{
    public class Enemy_Zombie : BaseEnemy, IEnemyInstance
    {
        public Enemy_Zombie()
        {
            UniqueId = Guid.NewGuid();
            Reset();
        }
        public override string Name => "Zombie";
        public override int BaseMaxHealth => 15;

        public Guid UniqueId { get; }
        public List<AfterTurnCountEvent> AfterTurnCountEvent { get; set; }
    }
}