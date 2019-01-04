using System.Collections.Generic;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Support.World
{
    public interface ICountBase
    {
        Dictionary<StatusEffect, int> StatusValues { get; set; }
    }
}