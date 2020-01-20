using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class MessageCreateRequest : Response
    {
        private MessageSendModel messageModel;

        public MessageCreateRequest(bool success, MessageSendModel messageRequest)
        {
            this.messageModel = messageRequest;
            this.Success = success;
        }

        public MessageCreateRequest(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public MessageSendModel MessageModel
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
