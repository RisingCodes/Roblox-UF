using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Roblox_UF
{
    internal static class Functions
    {
        public const string Version = "1.0.3";
        private static readonly Random Random = new Random();

        public static string RandomString(int l)
        {
            return new string(Enumerable.Repeat("zxcvbnmasdfghjklqpwoeirutyABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", l)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }

        public static string GetMd5HashFromFile(string fileName)
        {
            using (var stream = File.OpenRead(fileName))
                return BitConverter.ToString(MD5.Create().ComputeHash(stream)).Replace("-", string.Empty);
        }

        public static void Logo()
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

        public class VersionControl
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
                
                GC.Collect();
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
                GC.Collect();
                return githubApi["assets"]?[0]?["browser_download_url"]?.ToString();
            }

            public static string GetGithubReleaseTag()
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
                GC.Collect();
                return githubApi["html_url"]?.ToString();
            }

            public static string GetGithubPublishedDate()
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
                GC.Collect();
                return githubApi["published_at"]?.ToString();
            }
        }
    }
}
