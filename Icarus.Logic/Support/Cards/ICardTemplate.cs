using System;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic
{
    public interface ICardTemplate
    {
        Guid UniqueCardId { get; }
        string Name { get; }
        string Description { get; }
        int Cost { get; }
        CardType CardType { get; }
        CardCostType CardCostType { get; }
        CardColor CardColor { get; }
        CardUseType CardUseType { get; set; }
        CardRarity CardRarity { get; }
        Type UpgradeTarget { get; }
    }
}