using System;

namespace Icarus.Logic.Events.Args
{
    public class CardDrawnEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }
}