using gotifySharp.Interfaces;
using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace gotifySharpIntergrationTests
{
    public static class Settings
    {
        public const string GOTIFY = "gotify-windows-amd64.exe";
        public static Process gotifyExe;

        public static int PORT = 30000;
        public static string URL = "127.0.0.1";
        public static string USERNAME = "admin";
        public static string PASSWORD = "admin";
        public static bool StartServer = true;
        public static IConfig Config = new AppConfig(USERNAME, PASSWORD, URL, PORT, "Http", "/");

    }
}
