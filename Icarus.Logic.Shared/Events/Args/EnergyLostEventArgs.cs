using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class EnergyLostEventArgs : EventArgs
    {
        public int LostAmount { get; set; }
    }
}