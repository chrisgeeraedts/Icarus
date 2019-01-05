using System;
using System.Collections.Generic;
using Icarus.Logic.Shared.Support.Enemies;

namespace Icarus.Logic.Enemies
{
    public class Enemy_Skeleton : BaseEnemy, IEnemyInstance
    {
        public Enemy_Skeleton()
        {
            UniqueId = Guid.NewGuid();
            Reset();
        }
        public override string Name => "Skeleton";
        public override int BaseMaxHealth => 19;

        public Guid UniqueId { get; }
        public List<AfterTurnCountEvent> AfterTurnCountEvent { get; set; }
    }
}