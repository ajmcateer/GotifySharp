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
    public class HealthApiIntergrationTest
    {
        [TestMethod]
        public async Task GetHealthStatusTest()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var res = await gotifySharp.GetHealthStatusAsync();
            res.Health.health.Should().Be("green");
        }
    }
}
