﻿using System.Collections.Generic;

namespace Icarus.Logic.Managers
{
    public class EnemyManager : IManager
    {
        private readonly GameWorldManager _gameWorldManager;

        public List<IEnemyInstance> Enemies { get; set; }

        public IEnemyInstance ActiveEnemeyInstance { get; set; }

        public EnemyManager(GameWorldManager gameWorldManager)
        {
            _gameWorldManager = gameWorldManager;
        }

        public void Reset()
        {
            Enemies = new List<IEnemyInstance>();
        }

        public void DoDamage(int damage, IEnemyInstance enemyInstance)
        {
            ActiveEnemeyInstance = enemyInstance;

            //TODO calculate actual damage
            var actualDamage = damage;

           _gameWorldManager.HeroManager.TakeDamage(actualDamage);
        }
    }
}