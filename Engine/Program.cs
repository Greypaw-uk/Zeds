using System;
using Zeds.Engine;

namespace Zeds
{
#if WINDOWS || LINUX
    /// <summary>
    ///     The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (var game = new Engine.Zeds())
            {
                game.Run();
            }
        }
    }
#endif
}