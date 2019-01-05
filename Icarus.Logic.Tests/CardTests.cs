using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Icarus.Logic.Cards;
using Icarus.Logic.Enemies;
using Icarus.Logic.Events.Args;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards;

namespace Icarus.Logic.Tests
{
    [TestClass]
    public class CardTests
    {
        private Dictionary<Type, int> EventTriggers;

        private void LogEventTrigger(Type eventArgs)
        {
            if (!EventTriggers.ContainsKey(eventArgs))
            {
                EventTriggers.Add(eventArgs, 0);
            }
            EventTriggers[eventArgs] += 1;
        }


        private GameWorldManager Setup(ICardTemplate card, List<IEnemyInstance> availableEnemies)
        {
            EventTriggers = new Dictionary<Type, int>();

            Game.Hero = new Hero()
            {
                Name = "TestHero"
            };
            Game.Hero.Reset();

            Game.Hero.Deck.Add(card);

            GameWorldManager world = new GameWorldManager(Game.Hero, availableEnemies);
            world.Reset(Game.Hero, availableEnemies);
            world.CardManager.FillDeck();
            world.CardManager.CalculateEnergyCosts();
            world.CardManager.DrawFirstHand();

            // Connect all available events to logging
            world.EventManager.OnPlayerDamageTaken += delegate (object sender, PlayerDamageTakenEventArgs e) { LogEventTrigger(e.GetType()); };
            world.EventManager.OnPlayerStatusEffectAdded += delegate (object sender, PlayerStatusEffectAddedEventArgs e) { LogEventTrigger(e.GetType()); };
            world.EventManager.OnPowerActivated += delegate (object sender, PowerActivatedEventArgs e) { LogEventTrigger(e.GetType()); };


            return world;
        }



        [TestMethod]
        public void TestStrike()
        {
            // Arrange
            var card = new Strike();
            var enemies = new List<IEnemyInstance> {new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie()};
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> {enemies[0]};
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.EnemyManager.Enemies[0].ActualHealth, 6);
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
        }

        [TestMethod]
        public void TestBash()
        {
            // Arrange
            var card = new Bash();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.EnemyManager.Enemies[0].ActualHealth, 4);
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.EnemyManager.Enemies[0].StatusValues[StatusEffect.Vulnerable], 2);
        }

        [TestMethod]
        public void TestBashPlus()
        {
            // Arrange
            var card = new BashPlus();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.EnemyManager.Enemies[0].ActualHealth, 4);
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.EnemyManager.Enemies[0].StatusValues[StatusEffect.Vulnerable], 2);
        }

        [TestMethod]
        public void TestBashPlus2()
        {
            // Arrange
            var card = new BashPlus2();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.EnemyManager.Enemies[0].ActualHealth, 2);
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.EnemyManager.Enemies[0].StatusValues[StatusEffect.Vulnerable], 3);
        }


        [TestMethod]
        public void TestDefend()
        {
            // Arrange
            var card = new Defend();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.StatusValues[StatusEffect.Block], 5);
        }

        [TestMethod]
        public void TestDefendPlus()
        {
            // Arrange
            var card = new DefendPlus();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.StatusValues[StatusEffect.Block], 7);
        }

        [TestMethod]
        public void TestDefendPlus2()
        {
            // Arrange
            var card = new DefendPlus2();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.StatusValues[StatusEffect.Block], 10);
        }

        [TestMethod]
        public void TestAnger()
        {
            // Arrange
            var card = new Anger();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Anger), world));

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.EnemyManager.Enemies[0].ActualHealth, 6);
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.CardManager.DeckPile.Count, 0);
            Assert.AreEqual(world.CardManager.DiscardPile.Count, 2);
        }

        [TestMethod]
        public void TestArmaments()
        {
            // Arrange
            var card = new Arnaments();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);
            world.CardManager.Hand.Add(new CardInstance(typeof(Defend), world));

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { world.CardManager.Hand[1] };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.StatusValues[StatusEffect.Block], 5);
            Assert.AreEqual(world.CardManager.Hand[0].UniqueCardId, new Guid("f50d89a8-c94a-4583-8877-254d1d7af693"));
        }

        [TestMethod]
        public void TestBodySlam()
        {
            // Arrange
            var card = new BodySlam();
            var enemies = new List<IEnemyInstance> { new Enemy_Rat(), new Enemy_Skeleton(), new Enemy_Zombie() };
            var world = Setup(card, enemies);
            world.CardManager.Hand.Add(new CardInstance(typeof(Defend), world));

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { world.CardManager.Hand[1] };
            world.CardManager.Hand[1].Use(null, null);

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - (card.Cost + new Defend().Cost));
            Assert.AreEqual(world.EnemyManager.Enemies[0].ActualHealth, 7);
            Assert.AreEqual(world.StatusValues[StatusEffect.Block], 5);
        }

        [TestMethod]
        public void TestClash_canUse()
        {
            // Arrange
            var card = new Clash();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            world.CardManager.Hand.Add(new CardInstance(typeof(Strike), world));

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { world.CardManager.Hand[1] };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(86, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestClash_cannotUse()
        {
            // Arrange
            var card = new Clash();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            world.CardManager.Hand.Add(new CardInstance(typeof(Defend), world));

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { world.CardManager.Hand[1] };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(100, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestCleave()
        {
            // Arrange
            var card = new Cleave();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0], enemies[1], enemies[2] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(92, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(92, world.EnemyManager.Enemies[1].ActualHealth);
            Assert.AreEqual(92, world.EnemyManager.Enemies[2].ActualHealth);
        }

        [TestMethod]
        public void TestClothesline()
        {
            // Arrange
            var card = new Clothesline();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0], enemies[1], enemies[2] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(88, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(2, world.EnemyManager.Enemies[0].StatusValues[StatusEffect.Weak]);
        }

        [TestMethod]
        public void TestFlex()
        {
            // Arrange
            var card = new Flex();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0], enemies[1], enemies[2] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(2, world.StatusValues[StatusEffect.Strength]);

            world.GameTurnManager.StartNextTurn(); // Start enemy turn
            world.GameTurnManager.StartNextTurn(); // Start next player turn

            Assert.AreEqual(0, world.StatusValues[StatusEffect.Strength]);
        }

        [TestMethod]
        public void TestHeadbutt()
        {
            // Arrange
            var card = new Headbutt();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            world.CardManager.DiscardPile.Add(new CardInstance(typeof(Defend), world));

            // Act
            Guid id = world.CardManager.DiscardPile[0].UniqueId;
            var cardTargets = new List<ICardInstance>() { world.CardManager.DiscardPile[0] };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(91, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(true, world.CardManager.DeckPile.Any(x => x.UniqueId == id));
        }

        [TestMethod]
        public void TestHeavyBlade_NoStrength()
        {
            // Arrange
            var card = new HeavyBlade();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(86, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestHeavyBlade_2Strength()
        {
            // Arrange
            var card = new HeavyBlade();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            world.StatusValues[StatusEffect.Strength] = 2;
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(80, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestIronWave()
        {
            // Arrange
            var card = new IronWave();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(94, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(5, world.StatusValues[StatusEffect.Block]);
        }

        [TestMethod]
        public void TestPerfectedStrike_NoStrikes()
        {
            // Arrange
            var card = new PerfectedStrike();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(92, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestPerfectedStrike_3Strikes()
        {
            // Arrange
            var card = new PerfectedStrike();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(86, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestPommelStrike()
        {
            // Arrange
            var card = new PommelStrike();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };

            var cardInDeck = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck);

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(91, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(true, world.CardManager.Hand.Any(x => x.UniqueId == cardInDeck.UniqueId));
        }

        [TestMethod]
        public void TestShrugItOff()
        {
            // Arrange
            var card = new ShrugItOff();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };

            var cardInDeck = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck);

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(8, world.StatusValues[StatusEffect.Block]);
            Assert.AreEqual(true, world.CardManager.Hand.Any(x => x.UniqueId == cardInDeck.UniqueId));
        }

        [TestMethod]
        public void TestSwordBoomerang()
        {
            // Arrange
            var card = new SwordBoomerang();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            var totalHealthOfEnemies =
                world.EnemyManager.Enemies[0].ActualHealth +
                world.EnemyManager.Enemies[1].ActualHealth +
                world.EnemyManager.Enemies[2].ActualHealth;

            Assert.AreEqual(291, totalHealthOfEnemies);
        }

        [TestMethod]
        public void TestThunderclap()
        {
            // Arrange
            var card = new Thunderclap();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0], enemies[1], enemies[2] };

            // Act
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(96, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(96, world.EnemyManager.Enemies[1].ActualHealth);
            Assert.AreEqual(96, world.EnemyManager.Enemies[2].ActualHealth);
            Assert.AreEqual(1, world.EnemyManager.Enemies[0].StatusValues[StatusEffect.Vulnerable]);
            Assert.AreEqual(1, world.EnemyManager.Enemies[1].StatusValues[StatusEffect.Vulnerable]);
            Assert.AreEqual(1, world.EnemyManager.Enemies[2].StatusValues[StatusEffect.Vulnerable]);
        }

        [TestMethod]
        public void TestTrueGrit()
        {
            // Arrange
            var card = new TrueGrit();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0], enemies[1], enemies[2] };
            var cardInHand = new CardInstance(typeof(Strike), world);
            world.CardManager.Hand.Add(cardInHand);
            var cardTargets = new List<ICardInstance>() { world.CardManager.Hand[1] };
            // Act

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(7, world.StatusValues[StatusEffect.Block]);
            Assert.AreEqual(true, world.CardManager.ExhaustPile.Any(x => x.UniqueId == cardInHand.UniqueId));
        }

        [TestMethod]
        public void TestTwinStrike()
        {
            // Arrange
            var card = new TwinStrike();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };
            // Act

            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(90, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestWarCry()
        {
            // Arrange
            var card = new WarCry();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };


            var cardInHand = new CardInstance(typeof(Strike), world);
            world.CardManager.Hand.Add(cardInHand);
            var cardTargets = new List<ICardInstance>() { world.CardManager.Hand[1] };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(true, world.CardManager.DeckPile.Any(x => x.UniqueId == cardInHand.UniqueId));
        }

        [TestMethod]
        public void TestWildStrike()
        {
            // Arrange
            var card = new WildStrike();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };


            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);

            Assert.AreEqual(88, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(true, world.CardManager.DeckPile.Any(x => x.UniqueCardId ==  new Guid("2f37f6d9-8b5e-4255-ac9a-a831fe8d0b9c")));
        }


        [TestMethod]
        public void TestBattleTrance_CanUse()
        {
            // Arrange
            var card = new BattleTrance();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };


            var cardInDeck1 = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck1);

            var cardInDeck2 = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck2);

            var cardInDeck3 = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck3);

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);

            Assert.AreEqual(3, world.CardManager.Hand.Count);
        }

        [TestMethod]
        public void TestBattleTrance_CannotUse()
        {
            // Arrange
            var card = new BattleTrance();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };


            var cardInHand1 = new CardInstance(typeof(BattleTrance), world);
            world.CardManager.Hand.Add(cardInHand1);

            var cardInDeck1 = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck1);

            var cardInDeck2 = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck2);

            var cardInDeck3 = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck3);

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);

            Assert.AreEqual(4, world.CardManager.Hand.Count);
        }

        [TestMethod]
        public void TestBloodForBlood()
        {
            // Arrange
            var card = new BloodForBlood();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.EnemyManager.DoDamage(10, enemies[0]);
            world.CardManager.Hand[0].CalculateActualCost();

            // Assert
            Assert.AreEqual(3, world.CardManager.Hand[0].ActualCost);
        }

        [TestMethod]
        public void TestBloodForBloodMultipleHits()
        {
            // Arrange
            var card = new BloodForBlood();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.EnemyManager.DoDamage(10, enemies[0]);
            world.EnemyManager.DoDamage(10, enemies[0]);
            world.EnemyManager.DoDamage(10, enemies[0]);
            world.EnemyManager.DoDamage(10, enemies[0]);
            world.EnemyManager.DoDamage(10, enemies[0]);
            world.CardManager.Hand[0].CalculateActualCost();

            // Assert
            Assert.AreEqual(0, world.CardManager.Hand[0].ActualCost);
        }


        [TestMethod]
        public void TestBloodLetting()
        {
            // Arrange
            var card = new Bloodletting();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(97, world.HeroManager.Hero.CurrentHealthCount);
            Assert.AreEqual(world.HeroManager.EnergyCount + 1, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(1, EventTriggers[typeof(PlayerDamageTakenEventArgs)]);
        }

        [TestMethod]
        public void TestBurningPact()
        {
            // Arrange
            var card = new BurningPact();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };


            var cardInHand = new CardInstance(typeof(Strike), world);
            world.CardManager.Hand.Add(cardInHand);

            world.CardManager.DeckPile.Add(new CardInstance(typeof(Defend), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Defend), world));

            var cardTargets = new List<ICardInstance>() { cardInHand };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(1, world.CardManager.ExhaustPile.Count);
            Assert.AreEqual(1, world.CardManager.DiscardPile.Count);
            Assert.AreEqual(2, world.CardManager.Hand.Count);
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
        }


        [TestMethod]
        public void TestCarnage()
        {
            // Arrange
            var card = new Carnage();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(80, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestCombust_EnergyCost()
        {
            // Arrange
            var card = new Combust();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(1, world.HeroManager.ActivePowerCards.Count);
        }

        [TestMethod]
        public void TestCombust_PowerActivation()
        {
            // Arrange
            var card = new Combust();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            world.GameTurnManager.StartNextTurn();
            world.GameTurnManager.StartNextTurn();

            // Assert
            Assert.AreEqual(95, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(95, world.EnemyManager.Enemies[1].ActualHealth);
            Assert.AreEqual(95, world.EnemyManager.Enemies[2].ActualHealth);
            Assert.AreEqual(99, world.HeroManager.Hero.CurrentHealthCount);
        }

        [TestMethod]
        public void TestCorruption()
        {
            // Arrange
            var card = new Corruption();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };


            var cardInHand = new CardInstance(typeof(BurningPact), world);
            world.CardManager.Hand.Add(cardInHand);

            var cardInHand2 = new CardInstance(typeof(Carnage), world);
            world.CardManager.Hand.Add(cardInHand2);

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(0, world.CardManager.Hand[0].ActualCost);
            Assert.AreEqual(2, world.CardManager.Hand[1].ActualCost);
        }

        [TestMethod]
        public void TestDisarm()
        {
            // Arrange
            var card = new Disarm();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(-2, enemies[0].StatusValues[StatusEffect.Strength]);
        }

        [TestMethod]
        public void TestDropkick()
        {
            // Arrange
            var card = new Dropkick();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>() { };
            enemies[0].StatusValues[StatusEffect.Vulnerable] = 5;

            var cardInDeck1 = new CardInstance(typeof(Strike), world);
            world.CardManager.DeckPile.Add(cardInDeck1);

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount + 1 - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(1, world.CardManager.Hand.Count);
        }

        [TestMethod]
        public void TestDuelWield()
        {
            // Arrange
            var card = new DuelWield();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };

            var cardInHand1 = new CardInstance(typeof(Strike), world);
            world.CardManager.Hand.Add(cardInHand1);

            var cardTargets = new List<ICardInstance>() { cardInHand1 };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(2, world.CardManager.Hand.Count);
        }

        [TestMethod]
        public void TestEntrench()
        {
            // Arrange
            var card = new Entrench();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };
            world.StatusValues[StatusEffect.Block] = 10;

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(20, world.StatusValues[StatusEffect.Block]);
        }

        [TestMethod]
        public void TestEvolve_WithStatusCard()
        {
            // Arrange
            var card = new Evolve();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };

            world.CardManager.DeckPile.Add(new CardInstance(typeof(Wound), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            world.CardManager.DrawFromDeck();

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(2, world.CardManager.Hand.Count);
        }

        [TestMethod]
        public void TestFeelNoPain()
        {
            // Arrange
            var card = new FeelNoPain();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };


            world.CardManager.Hand.Add(new CardInstance(typeof(WarCry), world));

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.EnergyCount - card.Cost, world.HeroManager.CurrentEnergyCount);
            Assert.AreEqual(3, world.StatusValues[StatusEffect.Block]);
        }

        [TestMethod]
        public void TestFireBreathing_PowerActivation_ThisTurn()
        {
            // Arrange
            var card = new FireBreathing();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            world.EnemyManager.DoDamage(5, world.EnemyManager.Enemies[0]);
            world.EnemyManager.DoDamage(5, world.EnemyManager.Enemies[0]);
            world.GameTurnManager.StartNextTurn();

            // Assert
            Assert.AreEqual(98, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(98, world.EnemyManager.Enemies[1].ActualHealth);
            Assert.AreEqual(98, world.EnemyManager.Enemies[2].ActualHealth);
        }


        [TestMethod]
        public void TestFlameBarrier()
        {
            // Arrange
            var card = new FlameBarrier();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            world.EnemyManager.DoDamage(5, world.EnemyManager.Enemies[0]);
            world.EnemyManager.DoDamage(5, world.EnemyManager.Enemies[1]);

            // Assert
            Assert.AreEqual(12, world.StatusValues[StatusEffect.Block]);
            Assert.AreEqual(96, world.EnemyManager.Enemies[0].ActualHealth);
            Assert.AreEqual(96, world.EnemyManager.Enemies[1].ActualHealth);
        }

        [TestMethod]
        public void TestGhostlyArmor()
        {
            // Arrange
            var card = new GhostlyArmor();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(world.StatusValues[StatusEffect.Block], 10);
        }

        [TestMethod]
        public void TestHemokinesis()
        {
            // Arrange
            var card = new Hemokinesis();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { enemies[0] };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(97, world.HeroManager.Hero.CurrentHealthCount);
            Assert.AreEqual(86, world.EnemyManager.Enemies[0].ActualHealth);
        }

        [TestMethod]
        public void TestInfernalBlade()
        {
            // Arrange
            var card = new InfernalBlade();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(1, world.CardManager.Hand.Count);
        }

        [TestMethod]
        public void TestIntimidate()
        {
            // Arrange
            var card = new Intimidate();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);

            var enemyTargets = enemies;
            var cardTargets = new List<ICardInstance>();

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(world.HeroManager.CurrentEnergyCount, world.HeroManager.EnergyCount - card.Cost);
            Assert.AreEqual(1, world.EnemyManager.Enemies[0].StatusValues[StatusEffect.Weak]);
            Assert.AreEqual(1, world.EnemyManager.Enemies[1].StatusValues[StatusEffect.Weak]);
            Assert.AreEqual(1, world.EnemyManager.Enemies[2].StatusValues[StatusEffect.Weak]);
        }

        [TestMethod]
        public void TestMetallicize()
        {
            // Arrange
            var card = new Metallicize();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            world.GameTurnManager.StartNextTurn();

            // Assert
            Assert.AreEqual(3, world.StatusValues[StatusEffect.Block]);
            world.GameTurnManager.StartNextTurn();
            world.GameTurnManager.StartNextTurn();
            Assert.AreEqual(3, world.StatusValues[StatusEffect.Block]);
            world.GameTurnManager.StartNextTurn();
            world.GameTurnManager.StartNextTurn();
            Assert.AreEqual(3, world.StatusValues[StatusEffect.Block]);
            Assert.AreEqual(3, EventTriggers[typeof(PlayerStatusEffectAddedEventArgs)]);
        }

        [TestMethod]
        public void TestPowerThrough()
        {
            // Arrange
            var card = new PowerThrough();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };

            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(2, world.CardManager.Hand.Count);
            foreach (var cardInstance in world.CardManager.Hand)
            {
                Assert.AreEqual(typeof(Wound), cardInstance.CardBase);
            }
            Assert.AreEqual(15, world.StatusValues[StatusEffect.Block]);
        }

        [TestMethod]
        public void TestRage()
        {
            // Arrange
            var card = new Rage();
            var enemies = new List<IEnemyInstance> { new Enemy_TestDummy(), new Enemy_TestDummy(), new Enemy_TestDummy() };
            var world = Setup(card, enemies);
            var enemyTargets = new List<IEnemyInstance> { };
            var cardTargets = new List<ICardInstance>() { };


            world.CardManager.Hand.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.Hand.Add(new CardInstance(typeof(Strike), world));

            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            world.CardManager.DeckPile.Add(new CardInstance(typeof(Strike), world));
            // Act
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);

            // Assert
            Assert.AreEqual(0, world.StatusValues[StatusEffect.Block]);
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            Assert.AreEqual(3, world.StatusValues[StatusEffect.Block]);
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            Assert.AreEqual(6, world.StatusValues[StatusEffect.Block]);
            world.GameTurnManager.StartNextTurn();
            world.GameTurnManager.StartNextTurn();
            world.CardManager.Hand[0].Use(enemyTargets, cardTargets);
            Assert.AreEqual(0, world.StatusValues[StatusEffect.Block]);

        }
    }
}
