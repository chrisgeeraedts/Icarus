using System;

namespace Icarus.Logic.Events.Args
{
    public class PlayerStatusEffectAddedEventArgs : EventArgs
    {
        public StatusEffect StatusEffect { get; set; }
        public int StatusEffectAmount { get; set; }
    }
}