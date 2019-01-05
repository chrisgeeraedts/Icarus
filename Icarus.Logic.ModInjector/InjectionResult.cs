using System.Collections.Generic;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Support.Enemies;

namespace Icarus.Logic.ModInjector
{
    public class InjectionResult
    {
        public List<BaseHeroClass> HeroClasses { get; set; }
        public List<BaseCard> Cards { get; set; }
        public List<BaseEnemy> Enemies { get; set; }
    }
}