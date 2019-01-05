using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icarus.Logic.Cards;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Relic;

namespace Icarus.Logic.Classes
{
    public class MetalWarrior : BaseHeroClass
    {
        public override void BuildUpClass(Hero hero)
        {
            ClassName = "Metal Warrior";
            hero.CurrentHealthCount = 100;
            hero.HealthCount = 100;
            hero.Deck = new List<BaseCard>()
            {
                new Anger(),
                new Anger(),
                new Strike(),
                new Strike(),
                new Strike(),
                new Defend(),
                new Defend(),
                new Defend(),
                new PerfectedStrike(),
            };
            hero.Gold = 99;
            hero.Relics = new List<BaseRelic>();
            hero.Blights = new List<Blight>();
        
        }
    }
}
