using System;

namespace Icarus.Logic.Events.Args
{
    public class CardUsedEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }
}