using System;

namespace Icarus.Logic.Events.Args
{
    public class PlayerStatusEffectRemovedEventArgs : EventArgs
    {
        public StatusEffect StatusEffect { get; set; }
        public int StatusEffectAmount { get; set; }
    }
}