using System;
using System.Linq;
using System.Net;
using System.Threading;

namespace Roblox_UF
{
    internal static class Program
    {
        private const string Version = "1.0.2";
        private static readonly Random Random = new Random();

        private static string RandomString(int l)
        {
            return new string(Enumerable.Repeat("zxcvbnmasdfghjklqpwoeirutyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", l)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static void Logo()
        {
            const string logo = @"
  _____  _     _              _____          _           
 |  __ \(_)   (_)            / ____|        | |          
 | |__) |_ ___ _ _ __   __ _| |     ___   __| | ___  ___ 
 |  _  /| / __| | '_ \ / _` | |    / _ \ / _` |/ _ \/ __|
 | | \ \| \__ \ | | | | (_| | |___| (_) | (_| |  __/\__ \
 |_|  \_\_|___/_|_| |_|\__, |\_____\___/ \__,_|\___||___/
                        __/ |                            
                       |___/                             

";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(logo);
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
            Console.WriteLine("[1] - String Method\n[2] - Json Method");
            Console.Write("[+]> ");

            var command = Console.ReadLine() ?? throw new ArgumentNullException(Console.ReadLine());

            switch (command)
            {
                case "1":
                {
                    Console.Write("Username Length: ");
                    var num = Console.ReadLine() ?? throw new ArgumentNullException(Console.ReadLine());
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
            }
        }
    }
}
