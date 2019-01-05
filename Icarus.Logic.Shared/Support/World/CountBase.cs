using System;
using System.Collections.Generic;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Support.World
{
    public class CountBase : ICountBase
    {
        public CountBase()
        {
            StatusValues = new Dictionary<StatusEffect, int>();
            foreach (StatusEffect value in Enum.GetValues(typeof(StatusEffect)))
            {
                StatusValues.Add(value, 0);
            }
        }
        public Dictionary<StatusEffect, int> StatusValues { get; set; }
    }
}