using System;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Events.Args
{
    public class ShuffleCardEventArgs : EventArgs
    {
        public Type CardToShuffle { get; set; }
        public CardMovePoint ShuffleTargetPile { get; set; }
        public ShuffleFormat ShuffleFormat { get; set; }
    }
}