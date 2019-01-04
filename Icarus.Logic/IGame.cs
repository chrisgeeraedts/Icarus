using System.Collections.Generic;
using Icarus.Logic.Managers;
using Icarus.Logic.Support.Cards.Effects;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic
{
    public interface IGame 
    {
        EffectManager CardEffectManager { get; }
        CardManager CardManager { get; }
        GameTurnManager GameTurnManager { get; }
        EnemyManager EnemyManager { get; }
        HeroManager HeroManager { get; }
    }
}