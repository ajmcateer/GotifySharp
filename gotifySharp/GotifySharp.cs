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
using gotifySharp.Requests;
using static gotifySharp.Enums.ConnectionInfo;

namespace gotifySharp
{
    public class GotifySharp
    {
        private Client clientApi;
        private Message messageApi;
        private Application application;
        private Stream stream;
        private API.Version version;
        private API.Health health;

        public event EventHandler<Models.MessageModel> OnMessage;
        public event EventHandler<WebsocketDisconnectStatus> OnDisconnect;
        public event EventHandler<WebsocketReconnectStatus> OnReconnect;

        public GotifySharp(IConfig config)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IConfig>(config);

            //TODO convert to typed Client
            services.AddHttpClient("AdminAuth", c =>
            {
                c.BaseAddress = config.GetUri();
                c.DefaultRequestHeaders
    .               Add("accept", "application/json");
                c.DefaultRequestHeaders
                    .Add("authorization", "Basic " + config.GetBase64Auth());
            });

            //TODO convert to typed Client
            services.AddHttpClient("TokenAuth", c =>
            {
                c.BaseAddress = config.GetUri();
                c.DefaultRequestHeaders
                    .Add("accept", "application/json");
            });

            var contianer = services.BuildServiceProvider();

            clientApi = new Client(contianer);
            messageApi = new API.Message(contianer);
            application = new Application(contianer);
            stream = new Stream(contianer);
            version = new API.Version(contianer);
            health = new API.Health(contianer);

            stream.OnMessage += Stream_OnMessage;
            stream.OnDisconnect += Stream_OnDisconnect;
            stream.OnReconnect += Stream_OnReconnect;
        }

        private void Stream_OnReconnect(object sender, WebsocketReconnectStatus e)
        {
            OnReconnect?.Invoke(this, e);
        }

        private void Stream_OnDisconnect(object sender, WebsocketDisconnectStatus e)
        {
            OnDisconnect?.Invoke(this, e);
        }

        private void Stream_OnMessage(object sender, Models.MessageModel e)
        {
            OnMessage?.Invoke(this, e);
        }

        public void InitWebsocket()
        {
            stream.InitWebSocketAsync();
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ClientResponse> CreateClientAsync(string name)
        {
            return await clientApi.CreateClientAsync(name);
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<GetClientResponse> GetClientAsync()
        {
            return await clientApi.GetClientAsync();
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<ClientResponse> UpdateClientAsync(string id, string newName)
        {
            return await clientApi.UpdateClientAsync(id, newName);
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<bool> DeleteClientAsync(string id)
        {
            return await clientApi.DeleteClientAsync(id);
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<GetMessageResponse> GetAllMessageAsync(int amount=200, int since=0)
        {
            return await messageApi.GetAllMessages(amount, since);
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<MessageCreateRequest> SendMessage(string message, string title, string AppKey, int priority)
        {
            return await messageApi.CreateMessage(message, title, AppKey, priority);
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<GetMessageResponse> GetMessageForApplicationAsync(int id, int amount = 1, int since = 0)
        {
            return await messageApi.GetMessageForApplication(id.ToString(), amount, since);
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<GetApplicationResponse> GetApplications()
        {
            return await application.GetApplicationsAsync();
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<CreateApplicationResponse> CreateApplicationAsync(string name, string description)
        {
            return await application.CreateApplicationsAsync(name, description);
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<VersionResponse> GetVersionInfo()
        {
            return await version.GetVersionInfoAsync();
        }

        /// <exception cref="System.HttpRequestException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<HealthResponse> GetHealthStatusAsync()
        {
            return await health.GetHealthResponseAsync();
        }
    }
}
