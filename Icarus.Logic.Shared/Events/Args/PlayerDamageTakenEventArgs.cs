using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class PlayerDamageTakenEventArgs : EventArgs
    {
        public int DamageAmount { get; set; }
    }
}
