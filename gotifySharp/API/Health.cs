using gotifySharp.Models;
using gotifySharp.Responses;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharp.API
{
    public class Health
    {
        private const string path = "health";
        ServiceProvider services;

        public Health(ServiceProvider services)
        {
            this.services = services;
        }

        public async Task<HealthResponse> GetHealthResponseAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);

            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");

            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var parsedJson = JsonConvert.DeserializeObject<Models.Health>(await result.Content.ReadAsStringAsync());
                HealthResponse health = new HealthResponse(true, parsedJson);
                return health;
            }
            else
            {
                var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                HealthResponse health = new HealthResponse(false, parsedJson);
                return health;
            }
        }
    }
}
