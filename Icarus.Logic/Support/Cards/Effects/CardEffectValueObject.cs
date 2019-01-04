using System;

namespace Icarus.Logic.Support.Cards.Effects
{
    public class CardEffectValueObject
    {
        public CardEffectValueObject(Type type, Object value)
        {
            Type = type;
            Value = value;
        }
        public Type Type { get; set; }
        public Object Value { get; set; }
    }
}