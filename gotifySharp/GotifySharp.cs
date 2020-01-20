using gotifySharp.API;
using gotifySharp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using gotifySharp.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Dynamic;
using gotifySharp.Responses;

namespace gotifySharp
{
    public class GotifySharp
    {
        private Client clientApi;
        private Message messageApi;
        private Application application;
        private IExtendedHttpClient extendedHttpClient;
        private IExtendedHttpClient tokenHttpClient;

        public GotifySharp(IConfig config)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddHttpClient("AdminAuth", c =>
            {
                c.BaseAddress = config.GetUri();
                c.DefaultRequestHeaders
    .               Add("accept", "application/json");
                c.DefaultRequestHeaders
                    .Add("authorization", "Basic " + config.GetBase64Auth());
            });

            services.AddHttpClient("TokenAuth", c =>
            {
                c.BaseAddress = config.GetUri();
                c.DefaultRequestHeaders
                    .Add("accept", "application/json");
            });

            var contianer = services.BuildServiceProvider();

            clientApi = new Client(contianer);
            messageApi = new Message(contianer);
            application = new Application(contianer);
        }

        public async Task<ClientResponse> CreateClientAsync(string name)
        {
            return await clientApi.CreateClientAsync(name);
        }

        public async Task<ClientGetResponse> GetClientAsync()
        {
            return await clientApi.GetClientAsync();
        }

        public async Task<ClientResponse> UpdateClientAsync(string id, string newName)
        {
            return await clientApi.UpdateClientAsync(id, newName);
        }

        public async Task<bool> DeleteClientAsync(string id)
        {
            return await clientApi.DeleteClientAsync(id);
        }

        public async Task<MessageGetResponse> GetAllMessageAsync(int amount=200, int since=0)
        {
            return await messageApi.GetAllMessages(amount, since);
        }

        public async Task<MessageCreateRequest> SendMessage(string message, string title, string AppKey, int priority)
        {
            return await messageApi.CreateMessage(message, title, AppKey, priority);
        }

        public async Task<MessageGetResponse> GetMessageForApplicationAsync(int id, int amount = 200, int since = 0)
        {
            return await messageApi.GetMessageForApplication(id.ToString(), amount, since);
        }

        public async Task<ApplicationGetResponse> GetApplications()
        {
            return await application.GetApplicationsAsync();
        }

        public async Task<ApplicationCreateResponse> CreateApplicationAsync(string name, string description)
        {
            return await application.CreateApplicationsAsync(name, description);
        }
    }
}
