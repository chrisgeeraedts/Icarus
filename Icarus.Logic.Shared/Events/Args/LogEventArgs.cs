using System;

namespace Icarus.Logic.Shared.Events.Args
{
    public class NewLogMessageEventArgs : EventArgs
    {
        public string LogMessage { get; set; }
    }
}