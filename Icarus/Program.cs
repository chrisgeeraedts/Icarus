using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Icarus.Logic;
using Icarus.Logic.Cards;
using Icarus.Logic.Enemies;
using Icarus.Logic.Managers;

namespace Icarus
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Hero = new Hero()
            {
                Name = "TestHero"
            };
            Game.Hero.Reset();

            // Add some cards to the hero's deck
            Game.Hero.Deck.Add(new WildStrike());


            List<IEnemyInstance> enemies = new List<IEnemyInstance>
            {
                new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie()
            };


            GameWorldManager world = new GameWorldManager(Game.Hero, enemies);

            world.Reset(Game.Hero, enemies);
            world.CardManager.FillDeck();
            world.CardManager.CalculateEnergyCosts();
            world.CardManager.DrawFirstHand();

            world.CardManager.Hand[0].Use(world.EnemyManager.Enemies, null);

            Console.ReadKey();
        }
    }
}
