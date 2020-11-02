using System;
using System.Linq;
using System.Net;

namespace Roblox_UF
{
    internal static class Program
    {
        private const string Version = "1.0.1";

        private static readonly Random Random = new Random();

        private static string RandomString(int l)
        {
            const string chars = "zxcvbnmasdfghjklqpwoeirutyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, l)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static void Main()
        {
            var good = 0;
            var bad = 0;


            Console.Title =
                $"Good: [{long.Parse(good.ToString()):C0}] | Bad: [{long.Parse(bad.ToString()):C0}] | Version: {Version}";
            Console.Write("Username Length: ");
            var num = Console.ReadLine();
            Console.Clear();

            while (true)
            {
                Console.Title =
                    $"Good: [{long.Parse(good.ToString()):C0}] | Bad: [{long.Parse(bad.ToString()):C0}] | Version: {Version}";
                var username = RandomString(int.Parse(num ?? throw new InvalidOperationException()));
                using (var webClient = new WebClient())
                {
                    if (webClient.DownloadString($"https://api.roblox.com/users/get-by-username?username={username}")
                        .Contains("{\"success\":false,\"errorMessage\":\"User not found\"}"))
                    {
                        good++;
                        Console.WriteLine($"Good: {username}");
                    }
                    else
                    {
                        bad++;
                    }

                    webClient.Dispose();
                }
            }
        }
    }
}
