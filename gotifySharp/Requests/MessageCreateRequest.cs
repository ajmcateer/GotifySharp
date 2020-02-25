using gotifySharp.Models;
using gotifySharp.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Requests
{
    public class MessageCreateRequest : Response
    {
        private SendMessage messageModel;

        public MessageCreateRequest(bool success, SendMessage messageRequest)
        {
            this.messageModel = messageRequest;
            this.Success = success;
        }

        public MessageCreateRequest(bool success, RequestError errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public SendMessage MessageModel
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return messageModel;
                }
            }
            set
            {
                messageModel = value;
            }
        }
    }
}
