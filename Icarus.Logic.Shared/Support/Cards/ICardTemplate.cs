using System;
using System.Collections.Generic;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Shared.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Shared.Support.Cards
{
    public interface ICardTemplate
    {
        string Name { get; set; }
        string Description { get; set; }
        int Cost { get; set; }
        CardType CardType { get; set; }
        CardCostType CardCostType { get; set; }
        Guid UniqueCardId { get; set; }
        CardColor CardColor { get; set; }
        CardUseType CardUseType { get; set; }
        Dictionary<CardEffect, CardEffectValueObject> CardEffects { get; set; }
        Type UpgradeTarget { get; set; }
        CardRarity CardRarity { get; set; }
        AfterTurnCountEvent AfterTurnCountEvent { get; set; }
        bool Use(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets);
        bool UseOverridable(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets);
        bool CanUseOverridable(IGameWorldManager gameWorldManager, List<IEnemyInstance> targets, List<ICardInstance> cardTargets);
        int CalculateDamageOverridable(IGameWorldManager gameWorldManager, int baseDamage, IEnemyInstance target);
        int CalculateCostOverridable(IGameWorldManager gameWorldManager, ICardInstance cardInstance);
    }

}