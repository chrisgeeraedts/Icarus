using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Support.Enemies;

namespace Icarus.Logic.ModInjector
{
    public static class ModInjector
    {
        public static InjectionResult GetModContent()
        {
            var result = new InjectionResult();

            // use bin folder instead this:
            var modFolder = @"C:\Users\PC CHRIS\Source\Repos\chrisgeeraedts\Icarus\Icarus\bin\Debug\Mods";


            result.HeroClasses = new ClassInjector<BaseHeroClass>().Inject(modFolder);
            result.Cards = new ClassInjector<BaseCard>().Inject(modFolder);
            result.Enemies = new ClassInjector<BaseEnemy>().Inject(modFolder);



            return result;
        }
    }
}