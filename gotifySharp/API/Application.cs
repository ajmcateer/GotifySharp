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
    public class Application
    {
        private const string path = "application";
        private ServiceProvider services;

        public Application(ServiceProvider services)
        {
            this.services = services;
        }

        public async Task<ApplicationGetResponse> GetApplicationsAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, path);

                var httpclient = services.GetService<IHttpClientFactory>();
                var client = httpclient.CreateClient("AdminAuth");

                HttpResponseMessage result = await client.SendAsync(request);

                if (result.IsSuccessStatusCode)
                {
                    var parsedJson = JsonConvert.DeserializeObject<List<ApplicationGetModel>>(await result.Content.ReadAsStringAsync());
                    ApplicationGetResponse applicationModel = new ApplicationGetResponse(true, parsedJson);
                    return applicationModel;
                }
                else
                {
                    var parsedJson = JsonConvert.DeserializeObject<ErrorResponse>(await result.Content.ReadAsStringAsync());
                    ApplicationGetResponse applicationModel = new ApplicationGetResponse(false, parsedJson);
                    return applicationModel;
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<ApplicationCreateResponse> CreateApplicationsAsync(string name, string description)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, path);

            ApplicationCreateModel application = new ApplicationCreateModel();
            application.description = description;
            application.name = name;

            var str = JsonConvert.SerializeObject(application);

            request.Content = new StringContent(str,
                                    Encoding.UTF8,
                                    "application/json");

            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");

            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var parsedJson = JsonConvert.DeserializeObject<ApplicationModel>(await result.Content.ReadAsStringAsync());
                ApplicationCreateResponse applicationModel = new ApplicationCreateResponse(true, parsedJson);
                return applicationModel;
            }
            else
            {
                var parsedJson = JsonConvert.DeserializeObject<ErrorResponse>(await result.Content.ReadAsStringAsync());
                ApplicationCreateResponse applicationModel = new ApplicationCreateResponse(false, parsedJson);
                return applicationModel;
            }
        }
    }
}
