using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class GetApplicationResponse : Response
    {
        private List<ApplicationModel> applicationGetModel;

        public GetApplicationResponse(bool success, List<ApplicationModel> applicationGetModel)
        {
            this.applicationGetModel = applicationGetModel;
            this.Success = success;
        }

        public GetApplicationResponse(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public List<ApplicationModel> ClientResponse
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
