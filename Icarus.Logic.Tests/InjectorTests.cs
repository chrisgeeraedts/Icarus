using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Icarus.Logic.Cards;
using Icarus.Logic.Classes;
using Icarus.Logic.Enemies;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Events.Args;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Support.Cards;

namespace Icarus.Logic.Tests
{
    [TestClass]
    public class InjectorTests
    {
        [TestMethod]
        public void TestClassInjection()
        {
            var modContent = ModInjector.ModInjector.GetModContent();
            Assert.AreEqual(1, modContent.HeroClasses.Count);
            Assert.AreEqual(1, modContent.Cards.Count);
            Assert.AreEqual(1, modContent.Cards.Count);
        }
    }


    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void TestGameInit()
        {
            var foo = Game.Hero;
        }
    }
}
