using System;
using System.Collections.Generic;
using System.Linq;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Managers
{
    public class CardManager : IManager
    {
        private List<BaseCard> availableCardTemplates;

        public List<BaseCard> AvailableBaseCards
        {
            get
            {
                var items = new List<BaseCard>();
                items.AddRange(availableCardTemplates);
                return items;
            }
        }

        public int MaxHandSize
        {
            get 
            {
                return 8;
            }
        }

        public int PickCardCount
        {
            get
            {
                return 8;
            }
        }

        public void CalculateEnergyCosts()
        {
            foreach (var card in DeckPile)
            {
                card.CalculateActualCost();
            }

            foreach (var card in DiscardPile)
            {
                card.CalculateActualCost();
            }

            foreach (var card in Hand)
            {
                card.CalculateActualCost();
            }
        }

        public int CurrentPickCardCount { get; set; }
        public bool CanDrawCardsThisTurn
        {
            get => CanDrawCardsThisTurn;
            set => CanDrawCardsThisTurn = value;
        }

        private ICardInstance _lastCardPick;
        public ICardInstance LastCardPick
        {
            get { return _lastCardPick;}
            set
            {
                _lastCardPick = value;
                GameWorldManager.GameTurnManager.ActivateAvailablePowerTriggers(PowerTrigger.OnCardDraw);
            }
        } 

        private GameWorldManager GameWorldManager { get; }
        public List<ICardInstance> DeckPile { get; set; }
        public List<ICardInstance> DiscardPile { get; set; }
        public List<ICardInstance> ExhaustPile { get; set; }
        public List<ICardInstance> Hand { get; set; }


        private ICardInstance _lastCardExhausted;
        public ICardInstance LastCardExhausted
        {
            get { return _lastCardExhausted; }
            set
            {
                _lastCardExhausted = value;
                if (_lastCardExhausted.CardUseType == CardUseType.Exhaust)
                {
                    GameWorldManager.GameTurnManager.ActivateAvailablePowerTriggers(PowerTrigger.OnCardExhaust);
                }
            }
        }

        private ICardInstance _lastCardDiscarded;
        public ICardInstance LastCardDiscarded
        {
            get { return _lastCardDiscarded; }
            set
            {
                _lastCardDiscarded = value;
                if (_lastCardDiscarded.CardUseType == CardUseType.Default)
                {
                    GameWorldManager.GameTurnManager.ActivateAvailablePowerTriggers(PowerTrigger.OnCardDiscard);
                }
            }
        }


        public CardManager(GameWorldManager gameWorldManager)
        {
            GameWorldManager = gameWorldManager;
            availableCardTemplates = new List<BaseCard>();
            var type = typeof(IPlayableCardTemplate);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            foreach (var type1 in types.Where(x=> !x.IsAbstract))
            {
                var cardTemplate = (Activator.CreateInstance(type1) as BaseCard);
                availableCardTemplates.Add(cardTemplate);
            }
        }

        public void MoveCardBetweenPiles(ICardInstance cardInstance, CardMovePoint cardMoveSource, CardMovePoint cardMoveTarget)
        {
            Logger.Log($"Moving card: {cardInstance.Name}({cardInstance.UniqueId}) from {cardMoveSource} into {cardMoveTarget}");

            switch (cardMoveSource)
            {
                case CardMovePoint.Hand:
                    Hand.Remove(cardInstance);
                    break;
                case CardMovePoint.DiscardPile:
                    DiscardPile.Remove(cardInstance);
                    break;
                case CardMovePoint.ExhaustPile:
                    ExhaustPile.Remove(cardInstance);
                    break;
                case CardMovePoint.Deck:
                    DeckPile.Remove(cardInstance);
                    break;
                default:
                    break;
            }

            switch (cardMoveTarget)
            {
                case CardMovePoint.Hand:
                    Hand.Add(cardInstance);
                    break;
                case CardMovePoint.DiscardPile:
                    DiscardPile.Add(cardInstance);
                    break;
                case CardMovePoint.ExhaustPile:
                    ExhaustPile.Add(cardInstance);
                    break;
                case CardMovePoint.Deck:
                    DeckPile.Add(cardInstance);
                    break;
                default:
                    break;
            }

            GameWorldManager.EventManager.CardMovedBetweenPiles(cardMoveSource, cardMoveTarget, cardInstance);
        }

        public void DrawFirstHand()
        {
            Logger.Log($"Drawing first hand");

            for (int i = 0; i < CurrentPickCardCount; i++)
            {
                DrawFromDeck();
            }
        }
        public void DrawFromDeck()
        {
            ICardInstance cardToDraw;

            // check for decksize
            if (!DeckPile.Any())
            {
                // Shuffle deck from discardPile into deck
                DeckPile.AddRange(DiscardPile);
            }

            if (DeckPile.Any())
            {
                // pick top of deckpile
                cardToDraw = DeckPile.First();

                // Check for handsize
                if (Hand.Count >= MaxHandSize)
                {
                    // Drop pick to discard pile
                    DiscardPile.Add(cardToDraw);
                }
                else
                {
                    // drop pick to hand
                    Hand.Add(cardToDraw);
                    Logger.Log($"Drawing new card from Deck");
                }
                DeckPile.Remove(cardToDraw);
                LastCardPick = cardToDraw;
                GameWorldManager.EventManager.CardDrawn(cardToDraw);
            }

        }
        public void FillDeck()
        {
            Logger.Log($"Filling Deck with cards from Hero");
            foreach (var heroDeckCard in GameWorldManager.HeroManager.Hero.Deck)
            {
                DeckPile.Add(new CardInstance(heroDeckCard.GetType(), GameWorldManager));
            }
        }

        public void Reset()
        {

            CurrentPickCardCount = PickCardCount;
            DeckPile = new List<ICardInstance>();
            DiscardPile = new List<ICardInstance>();
            ExhaustPile = new List<ICardInstance>();
            Hand = new List<ICardInstance>();
        }

        public void AddCardToPile(ICardInstance newCard, CardMovePoint shuffleTargetPile, ShuffleFormat shuffleFormat)
        {
            Logger.Log($"Adding card: {newCard.Name}({newCard.UniqueId}) to {shuffleFormat} point of {shuffleTargetPile}");
            switch (shuffleTargetPile)
            {
                case CardMovePoint.Deck:
                    DeckPile.Insert(DetermineNewIndex(DeckPile.Count, shuffleFormat), newCard);
                    break;
                case CardMovePoint.Hand:
                    Hand.Insert(DetermineNewIndex(Hand.Count, shuffleFormat), newCard);
                    break;
                case CardMovePoint.DiscardPile:
                    DiscardPile.Insert(DetermineNewIndex(DiscardPile.Count, shuffleFormat), newCard);
                    break;
                case CardMovePoint.ExhaustPile:
                    ExhaustPile.Insert(DetermineNewIndex(ExhaustPile.Count, shuffleFormat), newCard);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shuffleTargetPile), shuffleTargetPile, null);
            }

            GameWorldManager.EventManager.ShuffleCard(newCard.CardBase, shuffleTargetPile, shuffleFormat);
        }

        private int DetermineNewIndex(int maxCount, ShuffleFormat shuffleFormat)
        {
            int index = new Random().Next(maxCount);
            switch (shuffleFormat)
            {
                case ShuffleFormat.Random:
                    return index;
                case ShuffleFormat.Top:
                    return 0;
                case ShuffleFormat.Bottom:
                    return maxCount;
                default:
                    throw new ArgumentOutOfRangeException(nameof(shuffleFormat), shuffleFormat, null);
            }
        }

        public void CreateRandomCard(CardColor targetCardColor, CardType targetCardType, CardMovePoint targetCardMovePoint, ShuffleFormat shuffleFormat)
        {
            var filteredListByColor = new List<BaseCard>();
            if (targetCardColor == CardColor.Any)
            {
                filteredListByColor.AddRange(availableCardTemplates.Where(x=> x.CardColor != CardColor.Curse));
            }
            else
            {
                filteredListByColor.AddRange(availableCardTemplates.Where(x => x.CardColor == targetCardColor));
            }
            
            var filteredListByColorAndType = new List<BaseCard>();
            if (targetCardType == CardType.Any)
            {
                filteredListByColorAndType.AddRange(filteredListByColor.Where(x => x.CardType != CardType.Curse && x.CardType != CardType.Status));
            }
            else
            {
                filteredListByColorAndType.AddRange(filteredListByColor.Where(x => x.CardType == targetCardType));
            }

            int randomIndex = new Random().Next(filteredListByColorAndType.Count -1);
            ICardInstance newCard = new CardInstance(filteredListByColorAndType[randomIndex].GetType(), GameWorldManager);
            Logger.Log($"Created a new card: {newCard.Name} ({newCard.UniqueId}) and placing it in {shuffleFormat} location of {targetCardMovePoint}");
            GameWorldManager.EventManager.CardCreated(targetCardMovePoint, newCard);
            AddCardToPile(newCard, targetCardMovePoint, shuffleFormat);
        }
    }
}