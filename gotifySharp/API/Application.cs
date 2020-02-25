using gotifySharp.Interfaces;
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
    internal class Application
    {
        private const string path = "application";
        private ServiceProvider services;

        public Application(ServiceProvider services)
        {
            this.services = services;
        }

        public async Task<GetApplicationResponse> GetApplicationsAsync()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, path))
            {
                var httpclient = services.GetService<IHttpClientFactory>();
                var client = httpclient.CreateClient("AdminAuth");

                using (HttpResponseMessage result = await client.SendAsync(request))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var parsedJson = JsonConvert.DeserializeObject<List<Models.ApplicationModel>>(await result.Content.ReadAsStringAsync());
                        GetApplicationResponse applicationModel = new GetApplicationResponse(true, parsedJson);
                        return applicationModel;
                    }
                    else
                    {
                        var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                        GetApplicationResponse applicationModel = new GetApplicationResponse(false, parsedJson);
                        return applicationModel;
                    }
                }
            }
        }

        public async Task<CreateApplicationResponse> CreateApplicationsAsync(string name, string description)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, path))
            {
                CreateApplication createApplication = new CreateApplication();
                createApplication.description = description;
                createApplication.name = name;

                var str = JsonConvert.SerializeObject(createApplication);

                request.Content = new StringContent(str,
                                        Encoding.UTF8,
                                        "application/json");

                var httpclient = services.GetService<IHttpClientFactory>();
                var client = httpclient.CreateClient("AdminAuth");

                using (HttpResponseMessage result = await client.SendAsync(request))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var parsedJson = JsonConvert.DeserializeObject<Models.ApplicationModel>(await result.Content.ReadAsStringAsync());
                        CreateApplicationResponse applicationModel = new CreateApplicationResponse(true, parsedJson);
                        return applicationModel;
                    }
                    else
                    {
                        var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                        CreateApplicationResponse applicationModel = new CreateApplicationResponse(false, parsedJson);
                        return applicationModel;
                    }
                }
            } 
        }
    }
}
