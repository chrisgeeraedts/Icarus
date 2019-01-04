using System;
using Icarus.Logic.ActiveSkill;
using Icarus.Logic.Events.Args;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Managers
{
    public class EventManager
    {
        public delegate void StatusUpdateHandler(object sender, PlayerDamageTakenEventArgs e);
        public event StatusUpdateHandler OnPlayerDamageTaken;

        public delegate void PlayerStatusEffectAddedHandler(object sender, PlayerStatusEffectAddedEventArgs e);
        public event PlayerStatusEffectAddedHandler OnPlayerStatusEffectAdded;

        public delegate void PlayerStatusEffectRemovedHandler(object sender, PlayerStatusEffectRemovedEventArgs e);
        public event PlayerStatusEffectRemovedHandler OnPlayerStatusEffectRemoved;

        public delegate void EnemyStatusEffectAddedHandler(object sender, EnemyStatusEffectAddedEventArgs e);
        public event EnemyStatusEffectAddedHandler OnEnemyStatusEffectAdded;

        public delegate void EnemyStatusEffectRemovedHandler(object sender, EnemyStatusEffectRemovedEventArgs e);
        public event EnemyStatusEffectRemovedHandler OnEnemyStatusEffectRemoved;

        public delegate void PowerActivatedHandler(object sender, PowerActivatedEventArgs e);
        public event PowerActivatedHandler OnPowerActivated;
        
        public delegate void CardExhaustedHandler(object sender, CardExhaustedEventArgs e);
        public event CardExhaustedHandler OnCardExhausted;

        public delegate void EnemyDamageTakenHandler(object sender, EnemyDamageTakenEventArgs e);
        public event EnemyDamageTakenHandler OnEnemyDamageTaken;

        public delegate void CardUsedHandler(object sender, CardUsedEventArgs e);
        public event CardUsedHandler OnCardUsed;

        public delegate void CardDrawnHandler(object sender, CardDrawnEventArgs e);
        public event CardDrawnHandler OnCardDrawn;

        public delegate void EnergyGainedHandler(object sender, EnergyGainedEventArgs e);
        public event EnergyGainedHandler OnEnergyGained;

        public delegate void EnergyLostHandler(object sender, EnergyLostEventArgs e);
        public event EnergyLostHandler OnEnergyLost;

        public delegate void PowerAddedToPlayerHandler(object sender, PowerAddedToPlayerEventArgs e);
        public event PowerAddedToPlayerHandler OnPowerAddedToPlayer;

        public delegate void ShuffleCardHandler(object sender, ShuffleCardEventArgs e);
        public event ShuffleCardHandler OnShuffleCard;

        public delegate void CardUpgradedHandler(object sender, CardUpgradedEventArgs e);
        public event CardUpgradedHandler OnCardUpgraded;

        public delegate void SkillCardActivatedHandler(object sender, SkillCardActivatedEventArgs e);
        public event SkillCardActivatedHandler OnSkillCardActivated;

        public void PlayerDamageTaken(int damageAmount)
        {
            if (OnPlayerDamageTaken == null) return;
            PlayerDamageTakenEventArgs args = new PlayerDamageTakenEventArgs() { DamageAmount = damageAmount };
            OnPlayerDamageTaken(this, args);
        }

        public void PlayerStatusEffectAdded(StatusEffect statusEffect, int statusEffectAmount)
        {
            if (OnPlayerStatusEffectAdded == null) return;
            PlayerStatusEffectAddedEventArgs args = new PlayerStatusEffectAddedEventArgs() { StatusEffect = statusEffect, StatusEffectAmount = statusEffectAmount };
            OnPlayerStatusEffectAdded(this, args);
        }

        public void PlayerStatusEffectRemoved(StatusEffect statusEffect, int statusEffectAmount)
        {
            if (OnPlayerStatusEffectRemoved == null) return;
            PlayerStatusEffectRemovedEventArgs args = new PlayerStatusEffectRemovedEventArgs() { StatusEffect = statusEffect, StatusEffectAmount = statusEffectAmount };
            OnPlayerStatusEffectRemoved(this, args);
        }

        public void EnemyStatusEffectAdded(StatusEffect statusEffect, int statusEffectAmount)
        {
            if (OnEnemyStatusEffectAdded == null) return;
            EnemyStatusEffectAddedEventArgs args = new EnemyStatusEffectAddedEventArgs() { StatusEffect = statusEffect, StatusEffectAmount = statusEffectAmount };
            OnEnemyStatusEffectAdded(this, args);
        }

        public void EnemyStatusEffectRemoved(StatusEffect statusEffect, int statusEffectAmount)
        {
            if (OnEnemyStatusEffectRemoved == null) return;
            EnemyStatusEffectRemovedEventArgs args = new EnemyStatusEffectRemovedEventArgs() { StatusEffect = statusEffect, StatusEffectAmount = statusEffectAmount };
            OnEnemyStatusEffectRemoved(this, args);
        }

        public void PowerActivated(ICardPower cardPower)
        {
            if (OnPowerActivated == null) return;
            PowerActivatedEventArgs args = new PowerActivatedEventArgs() { CardPower = cardPower };
            OnPowerActivated(this, args);
        }

        public void CardExhausted(ICardInstance cardInstance)
        {
            if (OnCardExhausted == null) return;
            CardExhaustedEventArgs args = new CardExhaustedEventArgs() { CardInstance = cardInstance };
            OnCardExhausted(this, args);
        }

        public void CardUsed(ICardInstance cardInstance)
        {
            if (OnCardUsed == null) return;
            CardUsedEventArgs args = new CardUsedEventArgs() { CardInstance = cardInstance };
            OnCardUsed(this, args);
        }

        public void EnemyDamageTaken(int damageAmount, IEnemyInstance enemyInstance)
        {
            if (OnEnemyDamageTaken == null) return;
            EnemyDamageTakenEventArgs args = new EnemyDamageTakenEventArgs() { DamageAmount = damageAmount, EnemyInstance = enemyInstance };
            OnEnemyDamageTaken(this, args);
        }

        public void CardDrawn(ICardInstance cardInstance)
        {
            if (OnCardDrawn == null) return;
            CardDrawnEventArgs args = new CardDrawnEventArgs() { CardInstance = cardInstance };
            OnCardDrawn(this, args);
        }

        public void EnergyGained(int gainedAmount)
        {
            if (OnEnergyGained == null) return;
            EnergyGainedEventArgs args = new EnergyGainedEventArgs() { GainedAmount = gainedAmount };
            OnEnergyGained(this, args);
        }

        public void EnergyLost(int lostAmount)
        {
            if (OnEnergyLost == null) return;
            EnergyLostEventArgs args = new EnergyLostEventArgs() { LostAmount = lostAmount };
            OnEnergyLost(this, args);
        }
        public void PowerAddedToPlayer(ICardPower cardPower)
        {
            if (OnPowerAddedToPlayer == null) return;
            PowerAddedToPlayerEventArgs args = new PowerAddedToPlayerEventArgs() { CardPower = cardPower };
            OnPowerAddedToPlayer(this, args);
        }

        public void ShuffleCard(Type cardToShuffle, CardMovePoint shuffleTargetPile, ShuffleFormat shuffleFormat)
        {
            if (OnShuffleCard == null) return;
            ShuffleCardEventArgs args = new ShuffleCardEventArgs() { ShuffleTargetPile = shuffleTargetPile, ShuffleFormat = shuffleFormat, CardToShuffle = cardToShuffle };
            OnShuffleCard(this, args);
        }

        public void CardUpgraded(ICardInstance baseCardInstance, BaseCard upgradeTarget, ICardInstance upgradedInstance)
        {
            if (OnCardUpgraded == null) return;
            CardUpgradedEventArgs args = new CardUpgradedEventArgs() { BaseCardInstance = baseCardInstance, UpgradeTarget = upgradeTarget, UpgradedInstance = upgradedInstance };
            OnCardUpgraded(this, args);
        }

        public void SkillCardActivated(BaseActiveSkill activeSkillCard)
        {
            if (OnSkillCardActivated == null) return;
            SkillCardActivatedEventArgs args = new SkillCardActivatedEventArgs() { ActiveSkillCard = activeSkillCard};
            OnSkillCardActivated(this, args);
        }
    }
}