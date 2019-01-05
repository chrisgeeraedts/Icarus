using System;
using System.Collections.Generic;
using System.Linq;
using Icarus.Logic.Classes;
using Icarus.Logic.ModInjector;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Support.Enemies;

namespace Icarus.Logic
{
    public static class Game
    {
        static Game()
        {
            AvailableClasses = new List<BaseHeroClass>();
            AvailableCards = new List<BaseCard>();
            AvailableEnemies = new List<BaseEnemy>();

            // Add base content
            AvailableClasses.Add(new MetalWarrior());
            AvailableCards.AddRange(LoadAvailableCards());
            AvailableEnemies.AddRange(LoadAvailableEnemies());

            // Add injected content
            var injectedContent = ModInjector.ModInjector.GetModContent();
            AvailableClasses.AddRange(injectedContent.HeroClasses);
            AvailableCards.AddRange(injectedContent.Cards);
            AvailableEnemies.AddRange(injectedContent.Enemies);
        }

        private static List<BaseCard> LoadAvailableCards()
        {
            var result = new List<BaseCard>();
            var type = typeof(BaseCard);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            foreach (var type1 in types.Where(x => !x.IsAbstract))
            {
                var cardTemplate = (Activator.CreateInstance(type1) as BaseCard);
                result.Add(cardTemplate);
            }

            return result;
        }

        private static List<BaseEnemy> LoadAvailableEnemies()
        {
            var result = new List<BaseEnemy>();
            var type = typeof(BaseEnemy);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            foreach (var type1 in types.Where(x => !x.IsAbstract))
            {
                var enemy = (Activator.CreateInstance(type1) as BaseEnemy);
                result.Add(enemy);
            }

            return result;
        }


        public static Hero Hero { get; set; }
        public static List<BaseHeroClass> AvailableClasses { get; set; }
        public static List<BaseCard> AvailableCards { get; set; }
        public static List<BaseEnemy> AvailableEnemies { get; set; }
    }
}