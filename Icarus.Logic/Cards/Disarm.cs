using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Disarm : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Disarm()
        {
            UniqueCardId = new Guid("360f51a4-054f-466a-b690-645df9b4dcab");
            CardEffects.Add(CardEffect.AddStrengthEnemy, new CardEffectValueObject(typeof(int), -2));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Exhaust;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Disarm";
            Description = "Enemy loses 2 Strength";
        }
    }
}