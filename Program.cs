using System;
using System.Linq;
using System.Net;

namespace Roblox_UF
{
    internal static class Program
    {
        private const string Version = "1.0.1b";
        private static readonly Random Random = new Random();

        private static string RandomString(int l) =>
            new string(Enumerable.Repeat("zxcvbnmasdfghjklqpwoeirutyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", l)
                .Select(s => s[Random.Next(maxValue: s.Length)]).ToArray());

        public static void Main()
        {
            var good = 0;
            var bad = 0;

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Title =
                $"Good: [{long.Parse(good.ToString()):C0}] | Bad: [{long.Parse(bad.ToString()):C0}] | Version: {Version}";
            Console.Write("Username Length: ");
            var num = Console.ReadLine() ?? throw new ArgumentNullException($"Console.ReadLine()");
            Console.Clear();

            while (true)
            {
                Console.Title =
                    $"Good: [{long.Parse(good.ToString()):C0}] | Bad: [{long.Parse(bad.ToString()):C0}] | Version: {Version}";
                var username = RandomString(int.Parse(num));
                using (var webClient = new WebClient())
                {
                    if (webClient.DownloadString($"https://api.roblox.com/users/get-by-username?username={username}")
                        .Contains("{\"success\":false,\"errorMessage\":\"User not found\"}"))
                    {
                        good++;
                        Console.WriteLine($"Good: {username}");
                    }
                    else
                        bad++;
                    webClient.Dispose();
                }
            }
        }
    }
}
