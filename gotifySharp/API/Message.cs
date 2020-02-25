using gotifySharp.Interfaces;
using gotifySharp.Models;
using gotifySharp.Requests;
using gotifySharp.Responses;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharp.API
{
    public class Message
    {
        private const string path = "message";
        private const string appPath = "application/NUM/message";
        ServiceProvider services;

        public Message(ServiceProvider services)
        {
            this.services = services;
        }

        public async Task<GetMessageResponse> GetAllMessages(int amount, int since)
        {
            var queryString = new Dictionary<string, string>()
            {
                { "amount", amount.ToString() },
                { "since", since.ToString() }
            };

            var requestUri = QueryHelpers.AddQueryString(path, queryString);

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");

            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            { 
                var parsedJson = JsonConvert.DeserializeObject<GetMessage>(await result.Content.ReadAsStringAsync());
                GetMessageResponse messageModel = new GetMessageResponse(true, parsedJson);
                return messageModel;
            }
            else
            {
                var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                GetMessageResponse clientModel = new GetMessageResponse(false, parsedJson);
                return clientModel;
            }
        }

        public async Task<MessageCreateRequest> CreateMessage(string message, string title, string AppKey, int prioity = 2)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Post, path))
            {
                request.Headers.Add("X-Gotify-Key", AppKey);

                SendMessage messageToSend = new SendMessage();
                messageToSend.title = title;
                messageToSend.message = message;
                messageToSend.priority = prioity;

                var str = JsonConvert.SerializeObject(messageToSend);

                request.Content = new StringContent(str,
                                        Encoding.UTF8,
                                        "application/json");

                var httpclient = services.GetService<IHttpClientFactory>();
                var client = httpclient.CreateClient("TokenAuth");

                using (HttpResponseMessage result = await client.SendAsync(request))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var parsedJson = JsonConvert.DeserializeObject<SendMessage>(await result.Content.ReadAsStringAsync());
                        MessageCreateRequest messageModel = new MessageCreateRequest(true, parsedJson);
                        return messageModel;
                    }
                    else
                    {
                        var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                        MessageCreateRequest messageModel = new MessageCreateRequest(false, parsedJson);
                        return messageModel;
                    }
                }
            }
        }

        public async Task<GetMessageResponse> GetMessageForApplication(string id, int amount, int since)
        {
            var queryString = new Dictionary<string, string>()
            {
                { "amount", amount.ToString() },
                { "since", since.ToString() }
            };

            var requestUri = QueryHelpers.AddQueryString(appPath.Replace("NUM", id), queryString);

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var httpclient = services.GetService<IHttpClientFactory>();
            var client = httpclient.CreateClient("AdminAuth");

            HttpResponseMessage result = await client.SendAsync(request);

            if (result.IsSuccessStatusCode)
            {
                var parsedJson = JsonConvert.DeserializeObject<GetMessage>(await result.Content.ReadAsStringAsync());
                GetMessageResponse messageModel = new GetMessageResponse(true, parsedJson);
                return messageModel;
            }
            else
            {
                var parsedJson = JsonConvert.DeserializeObject<RequestError>(await result.Content.ReadAsStringAsync());
                GetMessageResponse clientModel = new GetMessageResponse(false, parsedJson);
                return clientModel;
            }
        }
    }
}
