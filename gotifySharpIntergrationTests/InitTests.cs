using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace gotifySharpIntergrationTests
{
    [TestClass]
    public class InitTests
    {
        [AssemblyInitialize]
        public static void StartGo(TestContext testContext)
        {
            try
            {
                TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), Settings.PORT);
                tcpListener.Start();
                tcpListener.Stop();

                string path = System.Environment.GetEnvironmentVariable("GOTIFY_PATH");

                DeleteDB(path);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = path + Settings.GOTIFY;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.WorkingDirectory = path;
                Settings.gotifyExe = Process.Start(startInfo);
            }
            catch (SocketException socExp)
            {
                Settings.StartServer = false;
                Console.WriteLine("Port not open not starting server assuming its already running");
            }
        }

        public static void DeleteDB(string path)
        {
            string dbPath = $"{path}/data/gotify.db";
            if (File.Exists(dbPath))
            {
                //File.Delete(dbPath);
            }
        }

        [AssemblyCleanup]
        public static void EndGo()
        {
            Settings.gotifyExe.Kill(true);
        }
    }
}
