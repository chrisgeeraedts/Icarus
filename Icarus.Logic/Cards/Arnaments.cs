using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Arnaments : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public Arnaments()
        {
            UniqueCardId = new Guid("764d2334-94d2-48fd-8219-07cb51e54324");
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(typeof(int), 5));
            CardEffects.Add(CardEffect.UpgradeCard, null);
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Average;
            Cost = 1;
            Name = "Arnaments";
            Description = "Gain 5 Block and upgrade a card in your hand for the rest of combat.";
        }
    }
}