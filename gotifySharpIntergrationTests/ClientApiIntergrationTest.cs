using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using FluentAssertions;
using gotifySharp;
using gotifySharp.Models;
using gotifySharp.Interfaces;
using System.Threading.Tasks;
using gotifySharp.Responses;
using System.Net.Sockets;
using System.Net;

namespace gotifySharpIntergrationTests
{
    [TestClass]
    public class ClientApiIntergrationTest
    {
        [TestMethod]
        public async Task CreateClientTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var res = await gotifySharp.CreateClientAsync("Test");
            res.Success.Should().BeTrue();
        }

        [TestMethod]
        public async Task GetClientTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var res = await gotifySharp.CreateClientAsync("Test");
            var res2 = await gotifySharp.CreateClientAsync("Test2");
            var results = await gotifySharp.GetClientAsync();
            results.Success.Should().BeTrue();
        }

        [TestMethod]
        public async Task UpdateClientTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var createResponse = await gotifySharp.CreateClientAsync("Test");
            var results = await gotifySharp.UpdateClientAsync(createResponse.ClientModel.Id.ToString(), "NewName");
            results.Success.Should().BeTrue();
        }

        [TestMethod]
        public async Task DeleteClientTestAsync()
        {
            GotifySharp gotifySharp = new GotifySharp(Settings.Config);

            var createResponse = await gotifySharp.CreateClientAsync("Test");
            var results = await gotifySharp.DeleteClientAsync(createResponse.ClientModel.Id.ToString());
            results.Should().BeTrue();
        }
    }
}
