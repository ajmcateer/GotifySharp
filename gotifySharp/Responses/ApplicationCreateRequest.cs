using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class ApplicationCreateRequest : Response
    {
        private ApplicationCreateModel applicationCreateModel;

        public ApplicationCreateRequest(bool success, ApplicationCreateModel applicationCreateModel)
        {
            this.applicationCreateModel = applicationCreateModel;
            this.Success = success;
        }

        public ApplicationCreateRequest(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public ApplicationCreateModel ApplicationCreateModel
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return applicationCreateModel;
                }
            }
            set
            {
                applicationCreateModel = value;
            }
        }
    }
}
