using System;
using Icarus.Logic.Shared.Managers;

namespace Icarus.Logic.Shared.Utility
{
    public static class Logger
    {
        private static IGameWorldManager GameWorldManager { get; set; }
        public static void Reset(IGameWorldManager gameWorldManager)
        {
            GameWorldManager = gameWorldManager;
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
            GameWorldManager.EventManager.NewLogMessage(message);
        }
    }
}
