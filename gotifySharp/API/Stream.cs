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
        public event EventHandler OnClose;
        public event EventHandler OnOpen;
        public event EventHandler OnError;

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

            var ws = new WebSocket($"{protocol}://{appConfig.url}:{appConfig.port}/stream");
            ws.SetCredentials($"{appConfig.userName}", $"{appConfig.password}", true);
            ws.OnMessage += WsIncomingMessage;
            ws.OnClose += Ws_OnClose;
            ws.OnError += Ws_OnError;
            ws.OnOpen += Ws_OnOpen;
            ws.Connect();
        }

        private void Ws_OnOpen(object sender, EventArgs e)
        {
            OnOpen?.Invoke(this, null);
        }

        private void Ws_OnError(object sender, ErrorEventArgs e)
        {
            OnError?.Invoke(this, null);
        }

        private void Ws_OnClose(object sender, CloseEventArgs e)
        {
            OnClose?.Invoke(this, null);
        }

        private void WsIncomingMessage(object sender, MessageEventArgs e)
        {
            var parsedJson = JsonConvert.DeserializeObject<Models.MessageModel>(e.Data);
            OnMessage?.Invoke(this, parsedJson);
        }
    }
}
