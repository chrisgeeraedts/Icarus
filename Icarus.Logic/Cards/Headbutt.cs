using System;
using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Cards
{
    public class Headbutt : BaseCard, ICardTemplate
    {
        public Headbutt()
        {
            UniqueCardId = new Guid("3c27f381-00a0-415a-97ab-1d18337bbfaf");
            CardEffects.Add(CardEffect.Damage, new CardEffectValueObject(typeof(DamageMultipleTimesEffect), new DamageMultipleTimesEffect()
                { DamageAmount = 9, HitTimes = 1 }));
            CardColor = CardColor.Red;
            CardType = CardType.Attack;
            CardUseType = CardUseType.Default;
            UpgradeTarget = null;
            CardRarity = CardRarity.Normal;
            Cost = 1;
            Name = "Headbutt";
            Description = "Deal 9 damage. Put a card from your discard pile on top of you draw pile.";
        }

        public override bool UseOverridable(GameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets)
        {
            foreach (var cardTarget in cardTargets)
            {
                gameWorldManager.CardManager.MoveCardBetweenPiles(cardTarget, CardMovePoint.DiscardPile, CardMovePoint.Deck);
            }

            return true;
        }
    }
}