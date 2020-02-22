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
    public class Version
    {
        private const string path = "version";
        ServiceProvider services;

        public Version(ServiceProvider services)
        {
            this.services = services;
        }

        public async Task<VersionResponse> GetVersionInfoAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);

            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");

            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var parsedJson = JsonConvert.DeserializeObject<Models.Version>(await result.Content.ReadAsStringAsync());
                VersionResponse clientModel = new VersionResponse(true, parsedJson);
                return clientModel;
            }
            else
            {
                var parsedJson = JsonConvert.DeserializeObject<ErrorResponse>(await result.Content.ReadAsStringAsync());
                VersionResponse clientModel = new VersionResponse(false, parsedJson);
                return clientModel;
            }
        }
    }
}
