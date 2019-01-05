using System.Collections.Generic;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Shared.Managers
{
    public class EnemyManager : IManager
    {
        private readonly IGameWorldManager _gameWorldManager;

        public List<IEnemyInstance> Enemies { get; set; }

        public IEnemyInstance ActiveEnemyInstance { get; set; }

        public EnemyManager(IGameWorldManager gameWorldManager)
        {
            _gameWorldManager= gameWorldManager;
        }

        public void Reset()
        {
            Enemies = new List<IEnemyInstance>();
        }

        public void DoDamage(int damage, IEnemyInstance enemyInstance)
        {
            ActiveEnemyInstance = enemyInstance;

            //TODO calculate actual damage
            var actualDamage = damage;
            _gameWorldManager.HeroManager.MetaInformation[MetaInformation.TimesPlayerGotAttacked] += 1;
            _gameWorldManager.HeroManager.MetaInformation[MetaInformation.TimesPlayerGotAttackedThisTurn] += 1;

            // Handle potential skills that do something with attacks against the player
            _gameWorldManager.GameTurnManager.ActivateActiveSkillCardsThisTurn(ActiveSkillTrigger.OnBeingAttacked);

            _gameWorldManager.HeroManager.TakeDamage(actualDamage);
        }

        
    }
}