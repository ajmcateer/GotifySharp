using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class CreateApplicationResponse : Response
    {
        private ApplicationModel applicationModel;

        public CreateApplicationResponse(bool success, ApplicationModel applicationModel)
        {
            this.applicationModel = applicationModel;
            this.Success = success;
        }

        public CreateApplicationResponse(bool success, RequestError errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public ApplicationModel Response
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
