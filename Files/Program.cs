using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json.Linq;

namespace Roblox_UF
{
    internal static class Program
    {
        public static void Main()
        {
            Main:
            var good = 0;
            var bad = 0;
            
            Console.Title =
                $"Roblox UF [@RisingCodes] | Version: {Functions.Version}";
            Functions.Logo();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("[1] - String Method   |   [6] - Group Finder" +
                              "\n[2] - Json Method     |   [7] - Cookie Checker" +
                              "\n[3] - Credits & Links |   [8] - Cookie Generator" +
                              "\n[4] - Help            |" +
                              "\n[5] - Options         |");
            Console.Write("[+]> ");

            GC.Collect();

            switch (Console.ReadLine() ?? throw new ArgumentNullException())
            {
                case "1":
                {
                    Console.Clear();
                    Functions.Logo();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Lenght:\n    Minimum: 4\n    Maximum: 16");
                    Console.Write("Username Length: ");
                    var num = Console.ReadLine() ?? throw new ArgumentNullException();
                    Console.Clear();

                    while (true)
                    {
                        Console.Title =
                            $"Good: [{long.Parse(good.ToString()):C0}] | Bad: [{long.Parse(bad.ToString()):C0}] | Version: {Functions.Version}";
                        var username = Functions.RandomString(int.Parse(num));
                        using (var webClient = new WebClient())
                        {
                            webClient.Proxy = null;
                            if (webClient
                                .DownloadString($"https://api.roblox.com/users/get-by-username?username={username}")
                                .Contains("{\"success\":false,\"errorMessage\":\"User not found\"}"))
                            {
                                good++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Good: {username}");
                                GC.SuppressFinalize(webClient);
                            }
                            else
                            {
                                bad++;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(
                                    $"Bad: {username} | ID: {JObject.Parse(webClient.DownloadString($"https://api.roblox.com/users/get-by-username?username={username}"))["Id"]}");
                                GC.SuppressFinalize(webClient);
                            }
                            webClient.Dispose();
                        }
                    }
                }
                case "2":
                {
                    Console.Clear();
                    Functions.Logo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not Built Yet [Sleeping (3) Sec]");
                    Thread.Sleep(3000);
                    Console.Clear();
                    GC.Collect();
                    goto Main;
                }
                case "3":
                {
                    BackCredits:
                    Console.Clear();
                    Console.WriteLine(
                        "Credits [RisingCodes Team]:\n    Discord: HellFire#6953\n    V3rm: UnsourcedPyramid\n    Github: RisingCodes");
                    Console.WriteLine(
                        "Links:\n    V3rm: https://v3rmillion.net/member.php?action=profile&uid=1126847\n    Github: https://github.com/RisingCodes\n    Discord: https://discord.com/users/209504735726665728\n");
                    Console.Write("[Type Back to go Home Page]: ");
                    switch (Console.ReadLine() ?? throw new ArgumentNullException())
                    {
                        case "Back":
                        case "back":
                            Console.Clear();
                            goto Main;
                        default:
                            Console.Clear();
                            goto BackCredits;
                    }
                }
                case "4":
                {
                    BackHelp:
                    Console.Clear();
                    Functions.Logo();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(
                        "You can create a issue here: https://github.com/RisingCodes/Roblox-UF/issues\nYou can also contact me on Discord: HellFire#6953\n");
                    Console.Write("[Type Back to go Home Page]: ");
                    switch (Console.ReadLine() ?? throw new ArgumentNullException())
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
                case "5":
                {
                    BackOption:
                    Console.Clear();
                    Functions.Logo();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(
                        "Current Data:" +
                        $"\n    Current File Version: {Functions.Version} | Checksum: {Functions.GetMd5HashFromFile(Process.GetCurrentProcess().MainModule?.FileName)}" +
                        "\n" +
                        "\nLatest Data:" +
                        $"\n    Latest Version: {Functions.VersionControl.LatestVersionGithub()}" +
                        $"\n    Latest Version Tag: {Functions.VersionControl.GetGithubReleaseTag()}" +
                        $"\n    Published at: {Functions.VersionControl.GetGithubPublishedDate()}");
                    Console.Write("\n[To download the latest version type Download | type Back to go Home Page]: ");
                    switch (Console.ReadLine() ?? throw new ArgumentNullException())
                    {
                        case "download":
                        case "Download":
                            Console.Clear();
                            Functions.Logo();
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine("This file will be downloaded in a folder" +
                                              "\nwith the latest version name.");
                            using (var web = new WebClient())
                            {
                                Directory.CreateDirectory(Functions.VersionControl.LatestVersionGithub());
                                Console.WriteLine($"Created Directory: {Functions.VersionControl.LatestVersionGithub()}");
                                Console.WriteLine("Downloading...");
                                web.DownloadFile(Functions.VersionControl.BrowserDownloadGithub(),
                                    $"{Functions.VersionControl.LatestVersionGithub()}\\Roblox_UF {Functions.VersionControl.LatestVersionGithub()}.exe");
                                Console.WriteLine(
                                    $"Download Finished Directory: {Functions.VersionControl.LatestVersionGithub()}\\Roblox_UF {Functions.VersionControl.LatestVersionGithub()}.exe");
                                Console.WriteLine("The directory is at the same place as this program.");
                                Console.Write("[Type Back to go Home Page]: ");
                                switch (Console.ReadLine() ?? throw new ArgumentNullException())
                                {
                                    case "Back":
                                    case "back":
                                        Console.Clear();
                                        goto Main;
                                    default:
                                        Console.Clear();
                                        goto BackOption;
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
                case "6":
                {
                    Console.Clear();
                    Functions.Logo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not Built Yet [Sleeping (3) Sec]");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto Main;
                }
                case "7":
                {
                    Console.Clear();
                    Functions.Logo();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not Built Yet [Sleeping (3) Sec]");
                    Thread.Sleep(3000);
                    Console.Clear();
                    goto Main;
                }
            }
        }
    }
}
