using System;

namespace Icarus.Logic.Events.Args
{
    public class CardExhaustedEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }
}