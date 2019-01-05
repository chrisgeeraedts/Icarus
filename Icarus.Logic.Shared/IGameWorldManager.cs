using Icarus.Logic.Shared.Managers;

namespace Icarus.Logic.Shared
{
    public interface IGameWorldManager
    {
        EffectManager CardEffectManager { get; }
        CardManager CardManager { get; }
        GameTurnManager GameTurnManager { get; }
        EnemyManager EnemyManager { get; }
        HeroManager HeroManager { get; }
        EventManager EventManager { get; }
    }
}