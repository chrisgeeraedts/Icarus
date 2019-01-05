using System;
using Icarus.Logic.Support.Cards;

namespace Icarus.Logic.Shared.Events.Args
{
    public class PowerAddedToPlayerEventArgs : EventArgs
    {
        public ICardPower CardPower { get; set; }
    }
}