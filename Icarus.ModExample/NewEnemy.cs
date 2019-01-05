using Icarus.Logic.Shared.Support.Enemies;

namespace Icarus.ModExample
{
    public class NewEnemy : BaseEnemy
    {
        public override string Name => "New Modded Enemy";
        public override int BaseMaxHealth => 100;
    }
}