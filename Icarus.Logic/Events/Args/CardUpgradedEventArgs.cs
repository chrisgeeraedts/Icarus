using System;

namespace Icarus.Logic.Events.Args
{
    public class CardUpgradedEventArgs : EventArgs
    {
        public ICardInstance BaseCardInstance { get; set; }
        public BaseCard UpgradeTarget { get; set; }
        public ICardInstance UpgradedInstance { get; set; }
    }
}