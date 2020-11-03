using System;
using System.Linq;
using System.Net;
using System.Threading;

namespace Roblox_UF
{
    internal static class Program
    {
        private const string Version = "1.0.2b";
        private static readonly Random Random = new Random();

        private static string RandomString(int l)
        {
            return new string(Enumerable.Repeat("zxcvbnmasdfghjklqpwoeirutyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", l)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        private static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
  _____  _     _              _____          _           
 |  __ \(_)   (_)            / ____|        | |          
 | |__) |_ ___ _ _ __   __ _| |     ___   __| | ___  ___ 
 |  _  /| / __| | '_ \ / _` | |    / _ \ / _` |/ _ \/ __|
 | | \ \| \__ \ | | | | (_| | |___| (_) | (_| |  __/\__ \
 |_|  \_\_|___/_|_| |_|\__, |\_____\___/ \__,_|\___||___/
                        __/ |                            
                       |___/                             

---------------------------------------------------------
|                                                       |
|                Made By RisingCodes Team               |
|            Find us on V3rm, Discord, Github           |
|                                                       |
---------------------------------------------------------

");
        }

        public static void Main()
        {
            Main:
            var good = 0;
            var bad = 0;

            Console.Title =
                $"Good: [{long.Parse(good.ToString()):C0}] | Bad: [{long.Parse(bad.ToString()):C0}] | Version: {Version}";
            Logo();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] - String Method\n[2] - Json Method\n[3] - Credits & Links\n[4] - Help");
            Console.Write("[+]> ");

            string command;
            switch (Console.ReadLine() ?? throw new ArgumentNullException())
            {
                case "1":
                {
                    Console.Clear();
                    Logo();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Lenght:\n    Minimum: 4\n    Maximum: 16");
                    Console.Write("Username Length: ");
                    var num = Console.ReadLine() ?? throw new ArgumentNullException();
                    Console.Clear();

                    while (true)
                    {
                        Console.Title =
                            $"Good: [{long.Parse(good.ToString()):C0}] | Bad: [{long.Parse(bad.ToString()):C0}] | Version: {Version}";
                        var username = RandomString(int.Parse(num));
                        using (var webClient = new WebClient())
                        {
                            if (webClient
                                .DownloadString($"https://api.roblox.com/users/get-by-username?username={username}")
                                .Contains("{\"success\":false,\"errorMessage\":\"User not found\"}"))
                            {
                                good++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Good: {username}");
                            }
                            else
                            {
                                bad++;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Bad: {username}");
                            }

                            webClient.Dispose();
                        }
                    }
                }
                case "2":
                    Console.Clear();
                    Logo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not Built Yet [Sleeping (3) Sec]");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto Main;
                case "3":
                    BackCredits:
                    Console.Clear();
                    Console.WriteLine(
                        "Credits [RisingCodes Team]:\n    Discord: HellFire#6953\n    V3rm: UnsourcedPyramid\n    Github: RisingCodes");
                    Console.WriteLine(
                        "Links:\n    V3rm: https://v3rmillion.net/member.php?action=profile&uid=1126847\n    Github: https://github.com/RisingCodes\n");
                    Console.Write("[Type Back to go Home Page]: ");
                    command = Console.ReadLine() ?? throw new ArgumentNullException();
                    switch (command)
                    {
                        case "Back":
                        case "back":
                            Console.Clear();
                            goto Main;
                        default:
                            Console.Clear();
                            goto BackCredits;
                    }
                case "4":
                    BackHelp:
                    Console.Clear();
                    Logo();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(
                        "You can create a issue here: https://github.com/RisingCodes/Roblox-UF/issues\nYou can also contact me on Discord: HellFire#6953\n");
                    Console.Write("[Type Back to go Home Page]: ");
                    command = Console.ReadLine() ?? throw new ArgumentNullException();
                    switch (command)
                    {
                        case "Back":
                        case "back":
                            Console.Clear();
                            goto Main;
                        default:
                            Console.Clear();
                            goto BackHelp;
                    }
            }
        }
    }
}
