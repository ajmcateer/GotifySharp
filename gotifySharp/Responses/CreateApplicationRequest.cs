using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class CreateApplicationRequest : Response
    {
        private CreateApplication applicationCreateModel;

        public CreateApplicationRequest(bool success, CreateApplication applicationCreateModel)
        {
            this.applicationCreateModel = applicationCreateModel;
            this.Success = success;
        }

        public CreateApplicationRequest(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public CreateApplication ApplicationCreateModel
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
