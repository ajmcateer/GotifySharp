using gotifySharp.Interfaces;
using gotifySharp.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;

namespace gotifySharp.API
{
    public class Stream
    {
        public event EventHandler<Models.MessageModel> OnMessage;

        const string path = "/stream";
        ServiceProvider services;
        IConfig appConfig;

        public Stream(ServiceProvider services)
        {
            this.services = services;
            appConfig = services.GetService<IConfig>();
        }

        public void InitWebSocket()
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

            var ws = new WebSocket($"{protocol}://{appConfig.url}/stream");
            ws.SetCredentials($"{appConfig.userName}", $"{appConfig.password}", true);
            ws.OnMessage += WsIncomingMessage;
            ws.Connect();
        }

        private void WsIncomingMessage(object sender, MessageEventArgs e)
        {
            var parsedJson = JsonConvert.DeserializeObject<Models.MessageModel>(e.Data);
            OnMessage?.Invoke(this, parsedJson);
        }
    }
}
