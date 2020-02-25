using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class GetMessageResponse : Response
    {
        private GetMessage messageGetModel;

        public GetMessageResponse(bool success, GetMessage clientResponse)
        {
            this.messageGetModel = clientResponse;
            this.Success = success;
        }

        public GetMessageResponse(bool success, RequestError errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public GetMessage MessageGetModel
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