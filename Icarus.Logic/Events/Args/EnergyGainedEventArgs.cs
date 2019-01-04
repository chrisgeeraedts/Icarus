using System;

namespace Icarus.Logic.Events.Args
{
    public class EnergyGainedEventArgs : EventArgs
    {
        public int GainedAmount { get; set; }
    }
}