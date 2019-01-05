using System;
using Icarus.Logic.Support.Cards;

namespace Icarus.Logic.Shared.Events.Args
{
    public class PowerActivatedEventArgs : EventArgs
    {
        public ICardPower CardPower { get; set; }
    }
}