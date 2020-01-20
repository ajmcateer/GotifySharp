using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class ApplicationCreateResponse : Response
    {
        private ApplicationModel applicationModel;

        public ApplicationCreateResponse(bool success, ApplicationModel applicationModel)
        {
            this.applicationModel = applicationModel;
            this.Success = success;
        }

        public ApplicationCreateResponse(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public ApplicationModel ClientResponse
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return applicationModel;
                }
            }
            set
            {
                applicationModel = value;
            }
        }
    }
}
