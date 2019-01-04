using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class WarCry : BaseCard, ICardTemplate
    {
        public WarCry()
        {
            UniqueCardId = new Guid("590f79c1-da0e-4d0a-8abf-fdf3498a10f6");
            CardEffects.Add(CardEffect.DrawCards, new CardEffectValueObject(typeof(int), 1));
            CardColor = CardColor.Red;
            CardType = CardType.Skill;
            CardUseType = CardUseType.Exhaust;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Warcry";
            Description = "Draw 1 card. Put a card from your hand onto the top of your draw pile.";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            foreach (var cardInstance in cardTargets)
            {
                gameWorldManager.CardManager.MoveCardBetweenPiles(cardInstance, CardMovePoint.Hand, CardMovePoint.Deck);
            }

            return true;
        }
    }
}