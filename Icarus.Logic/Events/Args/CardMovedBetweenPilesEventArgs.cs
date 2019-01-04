using System;
using Icarus.Logic.ActiveSkill;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Events.Args
{
    public class CardMovedBetweenPilesEventArgs : EventArgs
    {
        public CardMovePoint SourcePoint { get; set; }
        public CardMovePoint TargetPoint { get; set; }
        public ICardInstance CardInstance { get; set; }
    }

    public class CardCreatedEventArgs : EventArgs
    {
        public CardMovePoint TargetPoint { get; set; }
        public ICardInstance CardInstance { get; set; }
    }
}