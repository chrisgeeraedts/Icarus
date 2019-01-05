using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class TrueGrit : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public TrueGrit()
        {
            UniqueCardId = new Guid("a2e5e06e-3dbe-427e-8080-c0a1dfbeebfd");
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(typeof(int), 7));
            CardEffects.Add(CardEffect.ExhaustCard, null);
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "True Grit";
            Description = "Gain 7 Block. Exhaust a card in your hand";
        }
    }
}