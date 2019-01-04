using System;

namespace Icarus.Logic.Events.Args
{
    public class EnemyDamageTakenEventArgs : EventArgs
    {
        public int DamageAmount { get; set; }
        public IEnemyInstance EnemyInstance { get; set; }
    }
}