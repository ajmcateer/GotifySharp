using FluentAssertions;
using gotifySharp;
using gotifySharp.Interfaces;
using gotifySharp.Models;
using gotifySharp.Responses;
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
    public class MessageApiIntergrationTest
    {
        [TestMethod]
        public async Task GetAllMessagesTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var res = await gotifySharp.GetAllMessageAsync();
            res.Success.Should().BeTrue();
        }

        [TestMethod]
        public async Task SendMessageTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var app = await gotifySharp.CreateApplicationAsync("Name", "Description");
            var res = await gotifySharp.SendMessage("Message", "Test", app.ClientResponse.token, 2);
            res.Success.Should().BeTrue();
        }

        [TestMethod]
        public async Task GetMessagesForAppTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var app = await gotifySharp.CreateApplicationAsync("Name", "Description");
            var res = await gotifySharp.GetMessageForApplicationAsync(app.ClientResponse.id);
            res.Success.Should().BeTrue();
        }
    }
}
