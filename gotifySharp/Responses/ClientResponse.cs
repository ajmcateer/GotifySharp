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

        public ClientResponse(bool success, ErrorResponse errorResponse)
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
                    throw new NullReferenceException();
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
