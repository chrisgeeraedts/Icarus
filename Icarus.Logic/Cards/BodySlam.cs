using System;
using Icarus.Logic.Shared.Support.Cards;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class BodySlam : BaseCard, ICardTemplate, IPlayableCardTemplate
    {
        public BodySlam()
        {
            UniqueCardId = new Guid("8df6594b-0e7e-4609-91cb-57cbbde759df");
            CardEffects.Add(CardEffect.DamageAsBlock, null);
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Body Slam";
            Description = "Deal damage equal to your Block";
        }
    }
}