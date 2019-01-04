using System;

namespace Icarus.Logic.Events.Args
{
    public class PlayerDamageTakenEventArgs : EventArgs
    {
        public int DamageAmount { get; set; }
    }
}
