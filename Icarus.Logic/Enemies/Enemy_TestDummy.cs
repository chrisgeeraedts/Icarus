using System;
using System.Collections.Generic;

namespace Icarus.Logic.Enemies
{
    public class Enemy_TestDummy : BaseEnemy, IEnemyInstance
    {
        public Enemy_TestDummy()
        {
            UniqueId = Guid.NewGuid();
            Reset();
        }
        public override string Name => "TestDummy";
        public override int BaseMaxHealth => 100;

        public Guid UniqueId { get; }
        public List<AfterTurnCountEvent> AfterTurnCountEvent { get; set; }
    }
}