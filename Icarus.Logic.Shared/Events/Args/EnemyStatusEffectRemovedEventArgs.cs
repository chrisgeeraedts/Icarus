using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class EnemyStatusEffectRemovedEventArgs : EventArgs
    {
        public StatusEffect StatusEffect { get; set; }
        public int StatusEffectAmount { get; set; }
        public IEnemyInstance EnemyInstance { get; set; }
    }
}