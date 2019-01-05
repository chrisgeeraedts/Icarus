using Icarus.Logic.Support.World;

namespace Icarus.Logic.Shared.Support.Enemies
{
    public abstract class BaseEnemy : CountBase, IEnemyTemplate
    {
        public int ActualHealth { get; set; }

        public int ActualMaxHealth { get; set; }

        public abstract string Name { get; }

        public abstract int BaseMaxHealth { get; }

        public void Reset()
        {
            CalculateMaxHealth();
            ActualHealth = ActualMaxHealth;
        }

        public void CalculateMaxHealth()
        {
            ActualMaxHealth = BaseMaxHealth;
        }
    }
}