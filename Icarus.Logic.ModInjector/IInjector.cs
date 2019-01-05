using System.Collections.Generic;

namespace Icarus.Logic.ModInjector
{
    public interface IInjector<T>
    {
        List<T> Inject(string modFolder);
    }
}