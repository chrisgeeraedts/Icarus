using System;
using System.Collections.Generic;
using System.Linq;
using Icarus.Logic.Shared;

namespace Icarus.Logic.ModInjector
{
    public class ClassInjector<T> : IInjector<T>
    {
        public List<T> Inject(string modFolder)
        {
            List<T> result = new List<T>();
            var targetType = typeof(T);

            foreach (var modDllPath in System.IO.Directory.EnumerateFiles(modFolder))
            {
                var DLL = System.Reflection.Assembly.LoadFile(modDllPath);

                foreach (Type type in DLL.GetExportedTypes().Where(p => targetType.IsAssignableFrom(p)))
                {
                    var c = ((T)Activator.CreateInstance(type));
                    result.Add(c);
                }
            }

            return result;
        }
    }
}
