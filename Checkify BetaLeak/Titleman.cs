using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Checkify_BetaLeak
{
    class Titleman
    {
       async public static void Titler()
        {
            while (true)
            {
                try
                {
                    Console.Title = "Invites kekked: " + Program.successes;
                    Thread.Sleep(100);
                }
                catch (Exception)
                {
                    Thread.Sleep(100);

                }
            }
        }
    }
}
