using System;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Shared.Support.Cards.Effects
{
    public class ShuffleCardIntoPileEffect
    {
        public Type CardToShuffle { get; set; }
        public CardMovePoint ShuffleTargetPile { get; set; }
        public int CardAmount { get; set; }
        public ShuffleFormat ShuffleFormat { get; set; }
    }
}