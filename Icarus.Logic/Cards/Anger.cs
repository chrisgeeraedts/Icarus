using System;
using System.Collections.Generic;
using System.Linq;
using Icarus.Logic.Managers;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Anger : BaseCard, ICardTemplate
    {
        public Anger()
        {
            UniqueCardId = new Guid("3c27f381-00a0-415a-97ab-1d18337bbfaf");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 6, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 0;
            Name = "Strike";
            Description = "Deal 6 damage. Add a copy of this card into your discard pile.";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            var potentialCopy = gameWorldManager.CardManager.DeckPile.FirstOrDefault(x => x.UniqueCardId == new Guid("3c27f381-00a0-415a-97ab-1d18337bbfaf"));
            if (potentialCopy != null)
            {
                gameWorldManager.CardManager.MoveCardBetweenPiles(potentialCopy, CardMovePoint.Deck, CardMovePoint.DiscardPile);
            }
            else
            {
                var potentialCopyFromHand = gameWorldManager.CardManager.Hand.FirstOrDefault(x => x.UniqueCardId == new Guid("3c27f381-00a0-415a-97ab-1d18337bbfaf"));
                if (potentialCopyFromHand != null)
                {
                    gameWorldManager.CardManager.MoveCardBetweenPiles(potentialCopyFromHand, CardMovePoint.Hand, CardMovePoint.DiscardPile);
                }
            }
            return true;
        }
    }
}