namespace Icarus.Logic.Shared
{
    public abstract class BaseHeroClass
    {
        public string ClassName { get; set; }
        public abstract void BuildUpClass(Hero hero);
    }
}