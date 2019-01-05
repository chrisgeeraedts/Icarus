using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Shared.Support.Relic
{
    public abstract class BaseRelic
    {
        public abstract string Name { get; set; }
        public abstract RelicActivationTrigger RelicActivationTrigger { get; set; }
        public abstract bool ActivateEffect(IGameWorldManager gameWorldManager);
        public abstract bool CanActivateEffect(IGameWorldManager gameWorldManager);
    }
}