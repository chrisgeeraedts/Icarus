using System;
using Icarus.Logic.ActiveSkill;
using Icarus.Logic.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Events.Args
{
    public class PlayerDamageTakenEventArgs : EventArgs
    {
        public int DamageAmount { get; set; }
    }

    public class PlayerStatusEffectAddedEventArgs : EventArgs
    {
        public StatusEffect StatusEffect { get; set; }
        public int StatusEffectAmount { get; set; }
    }

    public class PlayerStatusEffectRemovedEventArgs : EventArgs
    {
        public StatusEffect StatusEffect { get; set; }
        public int StatusEffectAmount { get; set; }
    }

    public class EnemyStatusEffectAddedEventArgs : EventArgs
    {
        public StatusEffect StatusEffect { get; set; }
        public int StatusEffectAmount { get; set; }
        public IEnemyInstance EnemyInstance { get; set; }
    }

    public class EnemyStatusEffectRemovedEventArgs : EventArgs
    {
        public StatusEffect StatusEffect { get; set; }
        public int StatusEffectAmount { get; set; }
        public IEnemyInstance EnemyInstance { get; set; }
    }

    public class EnemyDamageTakenEventArgs : EventArgs
    {
        public int DamageAmount { get; set; }
        public IEnemyInstance EnemyInstance { get; set; }
    }

    public class CardUsedEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }

    public class CardExhaustedEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }

    public class CardDrawnEventArgs : EventArgs
    {
        public ICardInstance CardInstance { get; set; }
    }

    public class EnergyGainedEventArgs : EventArgs
    {
        public int GainedAmount { get; set; }
    }

    public class EnergyLostEventArgs : EventArgs
    {
        public int LostAmount { get; set; }
    }

    public class PowerActivatedEventArgs : EventArgs
    {
        public ICardPower CardPower { get; set; }
    }

    public class PowerAddedToPlayerEventArgs : EventArgs
    {
        public ICardPower CardPower { get; set; }
    }
    public class ShuffleCardEventArgs : EventArgs
    {
        public Type CardToShuffle { get; set; }
        public CardMovePoint ShuffleTargetPile { get; set; }
        public ShuffleFormat ShuffleFormat { get; set; }
    }
    public class CardUpgradedEventArgs : EventArgs
    {
        public ICardInstance BaseCardInstance { get; set; }
        public BaseCard UpgradeTarget { get; set; }
        public ICardInstance UpgradedInstance { get; set; }
    }

    public class SkillCardActivatedEventArgs : EventArgs
    {
        public BaseActiveSkill ActiveSkillCard { get; set; }
    }
}
