using System;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Bloodletting : BaseCard, ICardTemplate
    {
        public Bloodletting()
        {
            UniqueCardId = new Guid("8b8c062e-d085-4896-8c6b-82ea5cb4d04c");
            CardEffects.Add(CardEffect.GainEnergy, new CardEffectValueObject(typeof(int), 1));
            CardEffects.Add(CardEffect.LoseHealth, new CardEffectValueObject(typeof(int), 3));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Exhaust;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Bloodletting";
            Description = "Lose 3 HP, Gain 1 Energy";
        }
    }
}