using System;

namespace Icarus.Logic.Events.Args
{
    public class EnergyLostEventArgs : EventArgs
    {
        public int LostAmount { get; set; }
    }
}