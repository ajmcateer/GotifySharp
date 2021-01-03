using gotifySharp.Interfaces;
using gotifySharp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Websocket.Client;
using Websocket.Client.Models;
using static gotifySharp.Enums.ConnectionInfo;

namespace gotifySharp.API
{
    public class Stream : IDisposable
    {
        private WebsocketClient ws_client;
        public event EventHandler<MessageModel> OnMessage;
        public event EventHandler<WebsocketDisconnectStatus> OnDisconnect;
        public event EventHandler<WebsocketReconnectStatus> OnReconnect;

        const string path = "stream";
        ServiceProvider services;
        IConfig appConfig;

        public Stream(ServiceProvider services)
        {
            this.services = services;
            appConfig = services.GetService<IConfig>();
        }

        public async Task InitWebSocketAsync()
        {
            string protocol = "";

            if(appConfig.protocol == "Http")
            {
                protocol = "ws";
            }
            else
            {
                protocol = "wss";
            }

            Uri uri = new Uri($"{protocol}://{appConfig.url}:{appConfig.port}/{path}");

            var factory = new Func<ClientWebSocket>(() =>
            {
                var client = new ClientWebSocket
                {
                    Options =
                    {
                        KeepAliveInterval = TimeSpan.FromSeconds(5),
                    }
                };
                client.Options.SetRequestHeader("Authorization", $"Basic {Base64Encode($"{appConfig.userName}:{appConfig.password}")}");
                return client;
            });

            ws_client = new WebsocketClient(uri, factory);
            ws_client.MessageReceived.Subscribe(msg => WsIncomingMessage(msg));
            ws_client.DisconnectionHappened.Subscribe(msg => Ws_OnClose(msg));
            ws_client.ReconnectionHappened.Subscribe(msg => Ws_OnOpen(msg));
            await ws_client.Start();
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private void Ws_OnOpen(ReconnectionInfo reconnectionInfo)
        {
            var test = reconnectionInfo.Type;
            OnReconnect?.Invoke(this, (WebsocketReconnectStatus)reconnectionInfo.Type);
        }

        private void Ws_OnClose(DisconnectionInfo disconnectionInfo)
        {
            OnDisconnect?.Invoke(this, (WebsocketDisconnectStatus)disconnectionInfo.Type);
        }

        private void WsIncomingMessage(ResponseMessage msg)
        {
            var parsedJson = JsonConvert.DeserializeObject<Models.MessageModel>(msg.Text);
            OnMessage?.Invoke(this, parsedJson);
        }

        public void Dispose()
        {
            ws_client.Dispose();
        }
    }
}