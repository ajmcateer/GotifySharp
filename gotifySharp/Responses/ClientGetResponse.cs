using gotifySharp.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class ClientGetResponse : Response
    {
        private List<ClientGetModel> clientGetModel;

        public ClientGetResponse(bool success, List<ClientGetModel> clientResponse)
        {
            this.clientGetModel = clientGetModel;
            this.Success = success;
        }
        
        public ClientGetResponse(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public List<ClientGetModel> ClientResponse
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return clientGetModel;
                }
            }
            set
            {
                clientGetModel = value;
            }
        }
    }
}
