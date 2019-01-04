using System;
using System.Collections.Generic;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Managers
{
    public class HeroManager : IManager
    {
        private readonly GameWorldManager _gameWorldManager;

        List<IEnemyInstance> Enemies { get; set; }

        public HeroManager(GameWorldManager gameWorldManager)
        {
            _gameWorldManager = gameWorldManager;
        }

        public void Reset()
        {
            Enemies = new List<IEnemyInstance>();
            ActivePowerCards = new List<ICardPower>();
            EnergyCount = CalculateAvailableEnergy();
            CurrentEnergyCount = EnergyCount;
            MetaInformation = new Dictionary<MetaInformation, int>();
            foreach (MetaInformation metaInformation in Enum.GetValues(typeof(Support.Enums.MetaInformation)))
            {
                MetaInformation.Add(metaInformation, 0);
            }
        }

        public void TakeDamage(int damage)
        {
            //TODO: calculate the actual damage taken
            var actualDamageTaken = damage;

            if (actualDamageTaken > 0)
            {
                // Save meta information
                MetaInformation[Support.Enums.MetaInformation.AttacksPlayedThisTurn] += 1;

                // Handle damage calculation
                Hero.CurrentHealthCount -= actualDamageTaken;

                // Raise damage event
                _gameWorldManager.EventManager.PlayerDamageTaken(actualDamageTaken);
            }
        }
        
        public void SpendEnergy(int actualCost)
        {
            CurrentEnergyCount = CurrentEnergyCount - actualCost;
        }

        public Hero Hero { get; set; }

        public List<ICardPower> ActivePowerCards { get; set; }

        public int EnergyCount { get; set; }
        public int CurrentEnergyCount { get; set; }

        
        private int CalculateAvailableEnergy()
        {
            //TODO: do some actual calculation based on artifacts here
            return 30;
        }


        public Dictionary<MetaInformation, int> MetaInformation { get; set; }

    }
}