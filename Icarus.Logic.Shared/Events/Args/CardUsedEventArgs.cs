using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class CardUsedEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }
}