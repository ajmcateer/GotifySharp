using gotifySharp.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class ClientResponse : Response
    {
        private ClientModel clientResponse;

        public ClientResponse(bool success, ClientModel clientResponse)
        {
            this.ClientModel = clientResponse;
            this.Success = success;
        }

        public ClientResponse(bool success, RequestError errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public ClientModel ClientModel
        {
            get
            {
                if (!Success)
                {
                    return null;
                }
                else
                {
                    return clientResponse;
                }
            }
            set
            {
                clientResponse = value;
            }
        }
    }
}
