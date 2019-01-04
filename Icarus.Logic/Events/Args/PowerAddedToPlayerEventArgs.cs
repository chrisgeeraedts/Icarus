using System;
using Icarus.Logic.Support.Cards;

namespace Icarus.Logic.Events.Args
{
    public class PowerAddedToPlayerEventArgs : EventArgs
    {
        public ICardPower CardPower { get; set; }
    }
}