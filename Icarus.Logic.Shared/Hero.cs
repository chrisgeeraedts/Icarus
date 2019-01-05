using System;
using System.Collections.Generic;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Relic;
using Icarus.Logic.Shared.Utility;

namespace Icarus.Logic.Shared
{
    public class Hero
    {
        private BaseHeroClass _heroClass;
        public Hero(BaseHeroClass heroClass)
        {
            Relics = new List<BaseRelic>();
            _heroClass = heroClass;
            _heroClass.BuildUpClass(this);
        }

        public void Reset()
        {
            Deck = new List<BaseCard>();
            Blights = new List<Blight>();
            HealthCount = CalculateMaxHealthCount();
            CurrentHealthCount = HealthCount;
        }

        private int CalculateMaxHealthCount()
        {
            //TODO: actually calculate shit here
            return 100;
        }

        public string Name { get; set; }
        public List<BaseCard> Deck { get; set; }

        public int Gold { get; set; }

        public int HealthCount { get; set; }
        public int CurrentHealthCount { get; set; }

        public List<BaseRelic> Relics { get; set; }
        public List<Blight> Blights { get; set; }

        public void UpgradeCard(BaseCard baseCard)
        {
            if (baseCard.UpgradeTarget != null)
            {
                var resultCard = UpgradeCard(baseCard, baseCard.UpgradeTarget);
                Deck.Remove(baseCard);
                Deck.Add(resultCard);
            }
        }

        private BaseCard UpgradeCard(BaseCard baseCard, Type targetType)
        {
            var newCard = (Activator.CreateInstance(targetType) as BaseCard);
            Logger.Log($"Upgrading card {baseCard.Name} into {newCard.Name}");
            return newCard;
        }
    }
}