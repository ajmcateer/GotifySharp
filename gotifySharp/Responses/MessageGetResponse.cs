using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class MessageGetResponse : Response
    {
        private MessageGetModel messageGetModel;

        public MessageGetResponse(bool success, MessageGetModel clientResponse)
        {
            this.messageGetModel = clientResponse;
            this.Success = success;
        }

        public MessageGetResponse(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public MessageGetModel MessageGetModel
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return messageGetModel;
                }
            }
            set
            {
                messageGetModel = value;
            }
        }
    }
}