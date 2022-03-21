using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;


namespace Checkify_BetaLeak
{
    class checker
    {
        public static int minimumMembers;
        public static int maximumMembers;
        public static int realMembers;
        public static string output;
        public static string memberss;
        public static string members;
        public static string proxyString;
        public static int i;
        public static void Checker()
        {
            int inviteNumber = File.ReadAllLines("invites.txt").Length;
            int proxyNumber = File.ReadAllLines("httpProxies.txt").Length;

            for (i = 0; i < inviteNumber; i++)
            {


                string invites = File.ReadAllLines("invites.txt")[i];
                if (Program.proxies == true)
                {
                    try
                    {
                        Random rnd = new Random();

                        int proxyNum = rnd.Next(0, proxyNumber);
                        proxyString = File.ReadAllLines("httpProxies.txt")[proxyNum];
                    }
                    catch (Exception)
                    { }
                }



                string invite = invites.Split('/')[3];
                string Invite = invite.Split(' ')[0];
                string name = invite.Split(':')[1];

                try
                {
                    if (File.Exists("hit.txt"))
                    {
                        foreach (string dupeCheck in File.ReadAllLines("hit.txt"))
                        {
                            if (dupeCheck.Contains(name))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("DUPE DETECTED!");
                                Console.ForegroundColor = ConsoleColor.White;
                                goto skip;
                            }
                        }
                    }
                }
                catch (Exception)
                { }

                WebProxy wp = new WebProxy(proxyString);
                WebClient wc = new WebClient();





                try
                {
                    output = wc.DownloadString($"https://www.discord.com/api/v6/invites/{Invite}?with_counts=true");

                }
                catch (Exception)
                {
                    try
                    {
                        output = wc.DownloadString($"https://www.discord.com/api/v6/invites/{Invite}?with_counts=true");

                    }
                    catch (Exception)
                    {
                        goto skip;
                    }
                }

            waiter:
                Thread.Sleep(100);

                if (output.Contains("approximate_member_count"))
                {
                    var count = output.Where(c => c == ':').Count();

                    memberss = output.Split(':')[count - 1];
                    //memberss = 
                }
                else
                {
                    goto waiter;
                }
                try
                {
                    members = memberss.Split(',')[0];
                }
                catch (Exception)
                {

                    Thread.Sleep(10);
                }
                try
                {
                    minimumMembers = Int32.Parse(Program.minimumString);
                    maximumMembers = Int32.Parse(Program.maximumString);
                    realMembers = Int32.Parse(members);
                }
                catch (Exception)
                {

                    Thread.Sleep(10);
                }
                if (realMembers >= minimumMembers && realMembers < maximumMembers)
                {
                    File.AppendAllText("hit.txt", $"https://discord.gg/{Invite} - Name: {name} - Members: {members}\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"New server! Name:{name} -Members:{members}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Program.successes++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Server not within member bounds {realMembers}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            skip:
                Thread.Sleep(300);
            }
        }
    }
}
