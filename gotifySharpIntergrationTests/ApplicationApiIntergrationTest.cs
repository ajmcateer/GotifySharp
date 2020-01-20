using FluentAssertions;
using gotifySharp;
using gotifySharp.Interfaces;
using gotifySharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharpIntergrationTests
{
    [TestClass]
    public class ApplicationApiIntergrationTest
    {
        [TestMethod]
        public async Task GetApplicationsTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var res = await gotifySharp.GetApplications();
            res.Success.Should().BeTrue();
        }
    }
}
