using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class EnemyDamageTakenEventArgs : EventArgs
    {
        public int DamageAmount { get; set; }
        public IEnemyInstance EnemyInstance { get; set; }
    }
}