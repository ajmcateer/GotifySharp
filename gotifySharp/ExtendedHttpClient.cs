using gotifySharp.API;
using gotifySharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharp
{
    public class ExtendedHttpClient : IExtendedHttpClient
    {
        private static SocketsHttpHandler socketsHttpHandler;
        private static HttpClient httpClient;
        private IConfig config;

        public ExtendedHttpClient(IConfig config)
        {
            this.config = config;
            socketsHttpHandler = new SocketsHttpHandler();
            socketsHttpHandler.PooledConnectionLifetime = new TimeSpan(0, 15, 0);
            httpClient = new HttpClient(socketsHttpHandler);

            httpClient.BaseAddress = config.GetUri();
            httpClient.DefaultRequestHeaders
                .Add("accept", "application/json");
            httpClient.DefaultRequestHeaders
                .Add("authorization", "Basic " + config.GetBase64Auth());
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest)
        {
            return await httpClient.SendAsync(httpRequest);
        }
    }
}
