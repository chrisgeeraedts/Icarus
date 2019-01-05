using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class CardExhaustedEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }
}