﻿using System.Collections.Generic;
using Icarus.Logic.Shared.Utility;

namespace Icarus.Logic.Shared.Managers
{
    public interface IManager
    {
        void Reset();
    }

    public class GameWorldManager : IGameWorldManager
    {
        public EffectManager CardEffectManager { get; }
        public CardManager CardManager { get; }
        public GameTurnManager GameTurnManager { get; }
        public EnemyManager EnemyManager { get; }
        public HeroManager HeroManager { get; }
        public EventManager EventManager { get; }

        public GameWorldManager(Hero hero, List<IEnemyInstance> enemies)
        {
            Logger.Reset(this);
            CardEffectManager = new EffectManager(this);
            CardManager = new CardManager(this);
            GameTurnManager = new GameTurnManager(this);
            EventManager = new EventManager();
            EnemyManager = new EnemyManager(this) {Enemies = enemies};
            HeroManager = new HeroManager(this) {Hero = hero};
        }
        public void Reset(Hero hero, List<IEnemyInstance> enemies)
        {
            Logger.Log($"Resetting battleground");
            GameTurnManager.Reset();
            CardManager.Reset();
            CardEffectManager.Reset();
            EnemyManager.Reset();
            EnemyManager.Enemies = enemies;
            HeroManager.Reset();
            HeroManager.Hero = hero;
        }
    }
}