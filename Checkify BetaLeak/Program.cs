using System;
using System.Net;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Linq;

namespace Checkify_BetaLeak
{
    class Program
    {
        public static int successes;
        public static string minimumString;
        public static string maximumString;
        public static bool proxies;
        static void Main(string[] args)
        {
            Console.Title = "Checkify crack by Disabled - Real crack";
            Console.WriteLine("Minimum server members: ");
            minimumString = Console.ReadLine();
            Console.WriteLine("Maximum server members:");
            maximumString = Console.ReadLine();

            Console.WriteLine("Use proxies? Y/N: ");
            string proxiesYN = Console.ReadLine();
            if (proxiesYN == "Y" || proxiesYN == "y") {
                proxies = true;
                Console.WriteLine("Using proxies");
            } 

            Console.WriteLine("Reading invites from invites.txt");

            Thread thr = new Thread(checker.Checker);
            thr.Start();
            Titleman.Titler();



        }
    }
}
