using gotifySharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharp
{
    public class TokenHttpClient : IExtendedHttpClient
    {
        private static SocketsHttpHandler socketsHttpHandler;
        private static HttpClient httpClient;
        private IConfig config;

        public TokenHttpClient(IConfig config)
        {
            this.config = config;
            socketsHttpHandler = new SocketsHttpHandler();
            socketsHttpHandler.PooledConnectionLifetime = new TimeSpan(0, 15, 0);
            httpClient = new HttpClient(socketsHttpHandler);

            httpClient.BaseAddress = config.GetUri();
            httpClient.DefaultRequestHeaders
                .Add("accept", "application/json");
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequest)
        {
            return await httpClient.SendAsync(httpRequest);
        }
    }
}
