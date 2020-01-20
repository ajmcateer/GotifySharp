using Microsoft.VisualStudio.TestTools.UnitTesting;
using gotifySharp.Models;
using FluentAssertions;
using gotifySharp.API;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Moq;
using gotifySharp.Interfaces;
using gotifySharp;
using System;
using System.Threading.Tasks;

namespace gotifySharpTests
{
    [TestClass]
    public class ModelUnitTests
    {
        [TestMethod]
        public void VerifyAppConfigUriBuilderTest()
        {
            AppConfig appConfig = new AppConfig("admin", "admin", "example.com", 80);

            appConfig.GetUri().ToString().Should().Be("http://example.com:8080/");
        }


        [TestMethod]
        public void VerifyAppConfigBase64AuthTest()
        {
            AppConfig appConfig = new AppConfig("admin", "admin", "example.com", 80);

            appConfig.GetBase64Auth().Should().Be("YWRtaW46YWRtaW4=");
        }
    }
}
