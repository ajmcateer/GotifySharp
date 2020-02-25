using gotifySharp.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class GetClientResponse : Response
    {
        private List<GetClient> clientGetModel;

        public GetClientResponse(bool success, List<GetClient> clientResponse)
        {
            this.clientGetModel = clientGetModel;
            this.Success = success;
        }
        
        public GetClientResponse(bool success, RequestError errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public List<GetClient> ClientResponse
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
