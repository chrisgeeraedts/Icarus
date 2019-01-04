using System;
using System.Collections.Generic;
using Icarus.Logic.ActiveSkill;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Managers
{
    public class EffectManager : IManager
    {
        private readonly GameWorldManager _gameWorldManager;

        public EffectManager(GameWorldManager gameWorldManager)
        {
            _gameWorldManager = gameWorldManager;
        }

        public bool ActivateEffect(CardEffect cardEffect, CardEffectValueObject value, List<IEnemyInstance> targets, List<ICardInstance> cardTargets, BaseCard baseCard)
        {
            switch (cardEffect)
            {
                case CardEffect.Damage:
                    return DamageTarget(baseCard, (value.Value as DamageMultipleTimesEffect), targets);
                case CardEffect.AddVulnerableEnemy:
                    return AddVulnerableEnemy(Convert.ToInt32(value.Value), targets);
                case CardEffect.AddBlockEnemy:
                    return AddBlockEnemy(Convert.ToInt32(value.Value), targets);
                case CardEffect.AddStrengthEnemy:
                    return AddStrengthEnemy(Convert.ToInt32(value.Value), targets);
                case CardEffect.AddWeakEnemy:
                    return AddWeakEnemy(Convert.ToInt32(value.Value), targets);
                case CardEffect.AddVulnerableSelf:
                    return AddVulnerableSelf(Convert.ToInt32(value.Value));
                case CardEffect.AddBlockSelf:
                    return AddBlockSelf(Convert.ToInt32(value.Value));
                case CardEffect.AddStrengthSelf:
                    return AddStrengthSelf(Convert.ToInt32(value.Value));
                case CardEffect.AddWeakSelf:
                    return AddWeakSelf(Convert.ToInt32(value.Value));
                case CardEffect.UpgradeCard:
                    return UpgradeCards(cardTargets);
                case CardEffect.ExhaustCard:
                    return ExhaustCards(cardTargets);
                case CardEffect.DamageAsBlock:
                    return DamageAsBlockTarget(baseCard, targets);
                case CardEffect.DrawCards:
                    return DrawCards(Convert.ToInt32(value.Value));
                case CardEffect.DamageAllTargets:
                    return DamageTarget(baseCard, (value.Value as DamageMultipleTimesEffect), _gameWorldManager.EnemyManager.Enemies);
                case CardEffect.DamageRandomTargets:
                    return DamageRandomsTarget(baseCard, (value.Value as DamageMultipleTimesEffect), _gameWorldManager.EnemyManager.Enemies);
                case CardEffect.ShuffleCardIntoPile:
                    return ShuffleCardIntoPile((value.Value as ShuffleCardIntoPileEffect));
                case CardEffect.GainEnergy:
                    return GainEnergy(Convert.ToInt32(value.Value));
                case CardEffect.LoseHealth:
                    return LoseHealth(Convert.ToInt32(value.Value));
                case CardEffect.AddPowerToHero:
                    return AddPowerToHero(value.Value as ICardPower);
                case CardEffect.AddSkillThisTurn:
                    return AddSkillThisTurn(value.Value as BaseActiveSkill);
                default:
                    throw new NotImplementedException();
            }
        }

        private bool AddSkillThisTurn(BaseActiveSkill baseActiveSkill)
        {
            _gameWorldManager.GameTurnManager.ActiveSkillCardsThisTurn.Add(baseActiveSkill);
            return true;
        }

        private bool AddPowerToHero(ICardPower cardPower)
        {
            cardPower.GameWorldManager = _gameWorldManager;
            _gameWorldManager.HeroManager.ActivePowerCards.Add(cardPower);
            _gameWorldManager.EventManager.PowerAddedToPlayer(cardPower);
            return true;
        }

        public bool GainEnergy(int energyCount)
        {
            _gameWorldManager.HeroManager.CurrentEnergyCount += energyCount;
            if (energyCount > 0)
            {
                _gameWorldManager.EventManager.EnergyGained(energyCount);
            }
            else if (energyCount < 0)
            {
                _gameWorldManager.EventManager.EnergyLost(energyCount);
            }
            return true;
        }

        public bool LoseHealth(int damage)
        {
            _gameWorldManager.HeroManager.TakeDamage(damage);
            return true;
        }

        public bool ShuffleCardIntoPile(ShuffleCardIntoPileEffect shuffleCardIntoPileEffect)
        {
            for (int i = 0; i < shuffleCardIntoPileEffect.CardAmount; i++)
            {
                // Generate a new card
                Type baseCard = (Activator.CreateInstance(shuffleCardIntoPileEffect.CardToShuffle) as BaseCard).GetType();
                var newCard = new CardInstance(baseCard, _gameWorldManager);

                Logger.Log($"Shuffling card {newCard.Name} ({newCard.UniqueId}) into Pile: {shuffleCardIntoPileEffect.ShuffleTargetPile}");

                // Add to the pile
                _gameWorldManager.CardManager.AddCardToPile(newCard, shuffleCardIntoPileEffect.ShuffleTargetPile, shuffleCardIntoPileEffect.ShuffleFormat);
            }
            return true;
        }

        public bool DrawCards(int toInt32)
        {
            for (int i = 0; i < toInt32; i++)
            {
                _gameWorldManager.CardManager.DrawFromDeck();
            }
            return true;
        }

        public bool ExhaustCards(List<ICardInstance> cardTargets)
        {
            foreach (var cardTarget in cardTargets)
            {
                Logger.Log($"Exhausting card {cardTarget.Name} ({cardTarget.UniqueId})");
                if (cardTarget != null)
                {
                    if (_gameWorldManager.CardManager.Hand.Contains(cardTarget))
                    {
                        _gameWorldManager.CardManager.MoveCardBetweenPiles(cardTarget, CardMovePoint.Hand, CardMovePoint.ExhaustPile);
                        _gameWorldManager.CardManager.LastCardExhausted = cardTarget;
                    }
                    if (_gameWorldManager.CardManager.DeckPile.Contains(cardTarget))
                    {
                        _gameWorldManager.CardManager.MoveCardBetweenPiles(cardTarget, CardMovePoint.Deck, CardMovePoint.ExhaustPile);
                        _gameWorldManager.CardManager.LastCardExhausted = cardTarget;
                    }
                    if (_gameWorldManager.CardManager.DiscardPile.Contains(cardTarget))
                    {
                        _gameWorldManager.CardManager.MoveCardBetweenPiles(cardTarget, CardMovePoint.DiscardPile, CardMovePoint.ExhaustPile);
                        _gameWorldManager.CardManager.LastCardExhausted = cardTarget;
                    }
                }

                _gameWorldManager.EventManager.CardExhausted(cardTarget);
            }

            return true;
        }

        public bool DamageRandomsTarget(BaseCard baseCard, DamageMultipleTimesEffect damageMultipleTimesEffect, List<IEnemyInstance> gameWorldEnemies)
        {
            for (int i = 0; i < damageMultipleTimesEffect.HitTimes; i++)
            {
                Random rnd = new Random();
                int r = rnd.Next(gameWorldEnemies.Count);
                DamageTarget(baseCard, new DamageMultipleTimesEffect(){HitTimes = 1, DamageAmount = damageMultipleTimesEffect.DamageAmount }, 
                    new List<IEnemyInstance>() {gameWorldEnemies[r]});
            }
            return true;
        }

        public bool DamageAsBlockTarget(BaseCard card, List<IEnemyInstance> targets)
        {
            return DamageTarget(card, new DamageMultipleTimesEffect(){DamageAmount = _gameWorldManager.StatusValues[StatusEffect.Block] , HitTimes = 1}, targets);
        }
        public bool UpgradeCards(List<ICardInstance> cardTargets)
        {
            foreach (var cardTarget in cardTargets)
            {
                if (cardTarget.UpgradeTarget != null)
                {
                    //Then, upgrade it
                    var newCard = (Activator.CreateInstance(cardTarget.UpgradeTarget) as BaseCard);
                    var newCardInstance = new CardInstance(newCard.GetType(), _gameWorldManager);
                    //Then, replace the original one
                    if (_gameWorldManager.CardManager.Hand.Contains(cardTarget))
                    {
                        _gameWorldManager.CardManager.Hand[_gameWorldManager.CardManager.Hand.FindIndex(ind => ind.Equals(cardTarget))] = newCardInstance;
                        Logger.Log($"Upgrading card {cardTarget.Name} into {newCard.Name} in Hand");
                    }
                    else if (_gameWorldManager.CardManager.DeckPile.Contains(cardTarget))
                    {
                        _gameWorldManager.CardManager.DeckPile[_gameWorldManager.CardManager.Hand.FindIndex(ind => ind.Equals(cardTarget))] = newCardInstance;
                        Logger.Log($"Upgrading card {cardTarget.Name} into {newCard.Name} in Deck");
                    }
                    else if (_gameWorldManager.CardManager.DiscardPile.Contains(cardTarget))
                    {
                        _gameWorldManager.CardManager.DiscardPile[_gameWorldManager.CardManager.Hand.FindIndex(ind => ind.Equals(cardTarget))] = newCardInstance;
                        Logger.Log($"Upgrading card {cardTarget.Name} into {newCard.Name} in Discord");
                    }
                    _gameWorldManager.EventManager.CardUpgraded(cardTarget, newCard, newCardInstance);
                }
            }
            return true;
        }
        public bool DamageTarget(BaseCard card, DamageMultipleTimesEffect damageMultipleTimesEffect, List<IEnemyInstance> targets)
        {
            //TODO add calculation based on other variables
            foreach (var target in targets)
            {
                for (int i = 0; i < damageMultipleTimesEffect.HitTimes; i++)
                {
                    var damage = card.CalculateDamage(_gameWorldManager, damageMultipleTimesEffect.DamageAmount, target);
                    Logger.Log($"Damaging target: {target.Name}({target.UniqueId}) for {damage} damage");
                    target.ActualHealth = target.ActualHealth - damage;
                    _gameWorldManager.EventManager.EnemyDamageTaken(damage, target);
                }
            }
            return true;
        }

        public bool AddVulnerableEnemy(int baseVulnerable, List<IEnemyInstance> targets)
        {
            //TODO add calculation based on other variables
            foreach (var target in targets)
            {
                Logger.Log($"Adding {baseVulnerable} Vulnerable points to {target.Name}({target.UniqueId})");
                target.StatusValues[StatusEffect.Vulnerable] += baseVulnerable;
                RaiseStatusChangeEventEnemy(StatusEffect.Vulnerable, baseVulnerable);
            }
            return true;
        }
        public bool AddStrengthEnemy(int baseStrength, List<IEnemyInstance> targets)
        {
            //TODO add calculation based on other variables
            foreach (var target in targets)
            {
                Logger.Log($"Adding {baseStrength} Strength points to {target.Name}({target.UniqueId})");
                target.StatusValues[StatusEffect.Strength] += baseStrength;
                RaiseStatusChangeEventEnemy(StatusEffect.Strength, baseStrength);
            }
            return true;
        }
        public bool AddWeakEnemy(int baseWeak, List<IEnemyInstance> targets)
        {
            //TODO add calculation based on other variables
            foreach (var target in targets)
            {
                Logger.Log($"Adding {baseWeak} Weak points to {target.Name}({target.UniqueId})");
                target.StatusValues[StatusEffect.Weak] += baseWeak;
                RaiseStatusChangeEventEnemy(StatusEffect.Weak, baseWeak);
            }
            return true;
        }
        public bool AddBlockEnemy(int baseBlock, List<IEnemyInstance> targets)
        {
            //TODO add calculation based on other variables
            foreach (var target in targets)
            {
                Logger.Log($"Adding {baseBlock} Block points to {target.Name}({target.UniqueId})");
                target.StatusValues[StatusEffect.Block] += baseBlock;
                RaiseStatusChangeEventEnemy(StatusEffect.Block, baseBlock);
            }
            return true;
        }
        public bool AddBlockSelf(int baseBlock)
        {
            //TODO add calculation based on other variables
            Logger.Log($"Adding {baseBlock} Block points to Self");
            _gameWorldManager.StatusValues[StatusEffect.Block] += baseBlock;
            RaiseStatusChangeEventPlayer(StatusEffect.Block, baseBlock);
            return true;
        }
        public bool AddStrengthSelf(int baseStrength)
        {
            //TODO add calculation based on other variables
            Logger.Log($"Adding {baseStrength} Strength points to Self");
            _gameWorldManager.StatusValues[StatusEffect.Strength] += baseStrength;
            RaiseStatusChangeEventPlayer(StatusEffect.Strength, baseStrength);
            return true;
        }
        public bool AddWeakSelf(int baseWeak)
        {
            //TODO add calculation based on other variables
            Logger.Log($"Adding {baseWeak} Weak points to Self");
            _gameWorldManager.StatusValues[StatusEffect.Weak] += baseWeak;
            RaiseStatusChangeEventPlayer(StatusEffect.Weak, baseWeak);
            return true;
        }
        public bool AddVulnerableSelf(int baseVulnerable)
        {
            //TODO add calculation based on other variables
            Logger.Log($"Adding {baseVulnerable} Vulnerable points to Self");
            _gameWorldManager.StatusValues[StatusEffect.Vulnerable] += baseVulnerable;
            RaiseStatusChangeEventPlayer(StatusEffect.Vulnerable, baseVulnerable);
            
            return true;
        }

        private void RaiseStatusChangeEventPlayer(StatusEffect statusEffect, int amount)
        {
            if (amount > 0)
            {
                _gameWorldManager.EventManager.PlayerStatusEffectAdded(statusEffect, amount);
            }
            else if (amount < 0)
            {
                _gameWorldManager.EventManager.PlayerStatusEffectRemoved(statusEffect, amount);
            }
        }

        private void RaiseStatusChangeEventEnemy(StatusEffect statusEffect, int amount)
        {
            if (amount > 0)
            {
                _gameWorldManager.EventManager.EnemyStatusEffectAdded(statusEffect, amount);
            }
            else if (amount < 0)
            {
                _gameWorldManager.EventManager.EnemyStatusEffectRemoved(statusEffect, amount);
            }
        }

        public void Reset()
        {
        }
    }
}