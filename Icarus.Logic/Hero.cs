using System;
using System.Collections.Generic;

namespace Icarus.Logic
{
    public class Hero
    {
        public void Reset()
        {
            Deck = new List<ICardTemplate>();
            Relics = new List<Relic>();
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
        public List<ICardTemplate> Deck { get; set; }

        public int Gold { get; set; }

        public int HealthCount { get; set; }
        public int CurrentHealthCount { get; set; }

        public List<Relic> Relics { get; set; }
        public List<Blight> Blights { get; set; }

        public void UpgradeCard(ICardTemplate baseCard)
        {
            if (baseCard.UpgradeTarget != null)
            {
                var resultCard = UpgradeCard(baseCard, baseCard.UpgradeTarget);
                Deck.Remove(baseCard);
                Deck.Add(resultCard);
            }
        }

        private ICardTemplate UpgradeCard(ICardTemplate baseCard, Type targetType)
        {
            var newCard = (Activator.CreateInstance(targetType) as BaseCard);
            Logger.Log($"Upgrading card {baseCard.Name} into {newCard.Name}");
            return newCard;
        }
    }
}