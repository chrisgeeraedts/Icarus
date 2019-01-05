using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class EnergyGainedEventArgs : EventArgs
    {
        public int GainedAmount { get; set; }
    }
}