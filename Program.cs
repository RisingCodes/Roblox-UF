using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Newtonsoft.Json.Linq;

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

        private static string GetMd5HashFromFile(string fileName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
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
                $"Roblox UF [@RisingCodes] | Version: {Version}";
            Logo();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] - String Method" +
                              "\n[2] - Json Method" +
                              "\n[3] - Credits & Links" +
                              "\n[4] - Help " +
                              "\n[5] - Options");
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
                                Console.WriteLine(
                                    $"Bad: {username} | ID: {JObject.Parse(webClient.DownloadString($"https://api.roblox.com/users/get-by-username?username={username}"))["Id"]}");
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
                case "5":
                    BackOption:
                    Console.Clear();
                    Logo();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(
                        $"Current File Version: {Version} | Checksum: {GetMd5HashFromFile(Process.GetCurrentProcess().MainModule?.FileName)}" +
                        $"\nLatest Version: {VersionControl.LatestVersionGithub()}");
                    Console.Write("[To download the latest version type Download | type Back to go Home Page]: ");
                    command = Console.ReadLine() ?? throw new ArgumentNullException();
                    switch (command)
                    {
                        case "download":
                        case "Download":
                            Console.Clear();
                            Logo();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("This file will be downloaded in a folder" +
                                              "\nwith the latest version name.");
                            using (var web = new WebClient())
                            {
                                Directory.CreateDirectory(VersionControl.LatestVersionGithub());
                                Console.WriteLine($"Created Directory: {VersionControl.LatestVersionGithub()}");
                                Console.WriteLine("Downloading...");
                                web.DownloadFile(VersionControl.BrowserDownloadGithub(),
                                    $"{VersionControl.LatestVersionGithub()}\\Roblox_UF {VersionControl.LatestVersionGithub()}.exe");
                                Console.WriteLine(
                                    $"Download Finished Directory: {VersionControl.LatestVersionGithub()}\\Roblox_UF {VersionControl.LatestVersionGithub()}.exe");
                                Console.WriteLine("The directory is at the same place as this program.");
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
                        case "Back":
                        case "back":
                            Console.Clear();
                            goto Main;
                        default:
                            Console.Clear();
                            goto BackOption;
                    }
            }
        }

        private class VersionControl
        {
            public static string LatestVersionGithub()
            {
                var request =
                    WebRequest.CreateHttp("https://api.github.com/repos/RisingCodes/Roblox-UF/releases/latest");
                request.UserAgent =
                    "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.121 Safari/537.36";
                request.Method = "GET";
                request.Accept = "application/json";
                request.Credentials = CredentialCache.DefaultCredentials;

                var githubApi = JObject.Parse(
                    new StreamReader(
                        ((HttpWebResponse) request.GetResponse()).GetResponseStream() ??
                        throw new InvalidOperationException(), Encoding.UTF8).ReadToEnd());
                return githubApi["tag_name"]?.ToString();
            }

            public static string BrowserDownloadGithub()
            {
                var request =
                    WebRequest.CreateHttp("https://api.github.com/repos/RisingCodes/Roblox-UF/releases/latest");
                request.UserAgent =
                    "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/72.0.3626.121 Safari/537.36";
                request.Method = "GET";
                request.Accept = "application/json";
                request.Credentials = CredentialCache.DefaultCredentials;

                var githubApi = JObject.Parse(
                    new StreamReader(
                        ((HttpWebResponse) request.GetResponse()).GetResponseStream() ??
                        throw new InvalidOperationException(), Encoding.UTF8).ReadToEnd());
                return githubApi["assets"]?[0]?["browser_download_url"]?.ToString();
            }
        }
    }
}
