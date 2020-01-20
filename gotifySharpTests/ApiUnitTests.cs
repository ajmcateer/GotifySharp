using FluentAssertions;
using gotifySharp;
using gotifySharp.Interfaces;
using gotifySharp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharpTests
{
    [TestClass]
    public class ApiUnitTests
    {

        [TestMethod]
        public async Task CreateClientTestAsync()
        {
            var mockAppConfig = new Mock<IConfig>();
            var mockExtendedHttpClient = new Mock<IExtendedHttpClient>();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = System.Net.HttpStatusCode.OK;
            responseMessage.Content = new StringContent("{\"id\": 5," +
                "\"name\": \"Android Phone\"," +
                "\"token\": \"CWH0wZ5r0Mbac.r\"}");

            mockExtendedHttpClient.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(responseMessage);
            mockAppConfig.Setup(m => m.ExtendedHttpClient).Returns(mockExtendedHttpClient.Object);


            GotifySharp gotify = new GotifySharp(mockAppConfig.Object);
            IJsonResponse response = await gotify.CreateClientAsync("Android Phone");
            response.Should().BeOfType(typeof(ClientResponse));
        }

        [TestMethod]
        public async Task CreateClientTestFailureAsync()
        {
            var mockAppConfig = new Mock<IConfig>();
            var mockExtendedHttpClient = new Mock<IExtendedHttpClient>();
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage.StatusCode = System.Net.HttpStatusCode.BadRequest;
            responseMessage.Content = new StringContent("{\"error\": \"Unauthorized\"," +
                "\"errorCode\": 401," +
                "\"errorDescription\": \"you need to provide a valid access token or user credentials to access this api\"}");

            mockExtendedHttpClient.Setup(m => m.SendAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(responseMessage);
            mockAppConfig.Setup(m => m.ExtendedHttpClient).Returns(mockExtendedHttpClient.Object);


            GotifySharp gotify = new GotifySharp(mockAppConfig.Object);
            IJsonResponse response = await gotify.CreateClientAsync("Android Phone");
            response.Should().BeOfType(typeof(ClientResponse));
        }
    }
}
