﻿using gotifySharp.Interfaces;
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
    public class Client
    {
        private const string path = "client";
        ServiceProvider services;

        public Client(ServiceProvider services)
        {
            this.services = services;
        }

        public async Task<ClientResponse> CreateClientAsync(string name)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Content = new StringContent("{\"name\": \"" + name +"\"}",
                                    Encoding.UTF8,
                                    "application/json");

            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");
            
            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var parsedJson = JsonConvert.DeserializeObject<Responses.ClientModel>(await result.Content.ReadAsStringAsync());
                ClientResponse clientModel = new ClientResponse(true, parsedJson);
                return clientModel;
            }
            else
            {
                var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                ClientResponse clientModel = new ClientResponse(false, parsedJson);
                return clientModel;
            }
        }

        public async Task<GetClientResponse> GetClientAsync()
        {
            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");
            //cli.GetAsync(path);
            //var request = new HttpRequestMessage(HttpMethod.Get, path);

            //HttpResponseMessage result = await extendedHttpClient.SendAsync(request);
            HttpResponseMessage result = await client.GetAsync(path);

            if (result.IsSuccessStatusCode)
            {
                var parsedJson = JsonConvert.DeserializeObject<List<GetClient>>(await result.Content.ReadAsStringAsync());
                GetClientResponse clientModel = new GetClientResponse(true, parsedJson);
                return clientModel;
            }
            else
            {
                var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                GetClientResponse clientModel = new GetClientResponse(false, parsedJson);
                return clientModel;
            }
        }

        public async Task<ClientResponse> UpdateClientAsync(string id, string name)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Put, path + "/" + id))
            {
                request.Content = new StringContent("{\"name\": \"" + name + "\"}",
                    Encoding.UTF8,
                    "application/json");

                var httpclient = services.GetService<IHttpClientFactory>();
                var client = httpclient.CreateClient("AdminAuth");

                using (HttpResponseMessage result = await client.SendAsync(request))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var parsedJson = JsonConvert.DeserializeObject<Responses.ClientModel>(await result.Content.ReadAsStringAsync());
                        ClientResponse clientModel = new ClientResponse(true, parsedJson);
                        return clientModel;
                    }
                    else
                    {
                        var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                        ClientResponse clientModel = new ClientResponse(false, parsedJson);
                        return clientModel;
                    }
                }
            }
        }

        public async Task<bool> DeleteClientAsync(string id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, path + "/" + id);

            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");

            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
