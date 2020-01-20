using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class ApplicationGetResponse : Response
    {
        private List<ApplicationGetModel> applicationGetModel;

        public ApplicationGetResponse(bool success, List<ApplicationGetModel> applicationGetModel)
        {
            this.applicationGetModel = applicationGetModel;
            this.Success = success;
        }

        public ApplicationGetResponse(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public List<ApplicationGetModel> ClientResponse
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return applicationGetModel;
                }
            }
            set
            {
                applicationGetModel = value;
            }
        }
    }
}
