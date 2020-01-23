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

        public Stream(ServiceProvider services)
        {
            this.services = services;
            ListenForMessage();
        }

        private void ListenForMessage()
        {
            var ws = new WebSocket("ws://127.0.0.1:30000/stream");
            ws.OnMessage += WsIncomingMessage;
            ws.SetCredentials("admin", "admin", true);
            ws.Connect();
        }

        private void WsIncomingMessage(object sender, MessageEventArgs e)
        {
            var parsedJson = JsonConvert.DeserializeObject<Models.MessageModel>(e.Data);
            OnMessage?.Invoke(this, parsedJson);
        }
    }
}
