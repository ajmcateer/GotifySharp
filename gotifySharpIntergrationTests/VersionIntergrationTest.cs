using FluentAssertions;
using gotifySharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharpIntergrationTests
{
    [TestClass]
    public class VersionIntergrationTest
    {
        [TestMethod]
        public async Task GetAllMessagesTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var res = await gotifySharp.GetVersionInfo();
            res.Version.commit.Should().Be("7cf5c555f5b55e5080cb1f0d06aecd72809bebe8");
        }
    }
}
