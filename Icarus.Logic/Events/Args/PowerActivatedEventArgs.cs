using System;
using Icarus.Logic.Support.Cards;

namespace Icarus.Logic.Events.Args
{
    public class PowerActivatedEventArgs : EventArgs
    {
        public ICardPower CardPower { get; set; }
    }
}