using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class ShrugItOff : BaseCard, ICardTemplate
    {
        public ShrugItOff()
        {
            UniqueCardId = new Guid("a41ed1dc-2d36-40b6-ba45-e0b4695f2ccf");
            CardEffects.Add(CardEffect.AddBlockSelf, new CardEffectValueObject(typeof(int), 8));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Shrug It Off";
            Description = "Gain 8 Block. Draw 1 card.";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            gameWorldManager.CardManager.DrawFromDeck();
            return true;
        }
    }
}