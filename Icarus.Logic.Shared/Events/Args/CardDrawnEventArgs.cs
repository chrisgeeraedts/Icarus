using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class CardDrawnEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }
}