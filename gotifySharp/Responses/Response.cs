using gotifySharp.Interfaces;
using gotifySharp.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public abstract class Response : IJsonResponse
    {
        private RequestError errorResponse;
        public bool Success { get; set; }
        public RequestError ErrorResponse
        { 
            get
            { 
                if(Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return errorResponse;
                }
            }
            set
            {
                errorResponse = value;
            }
        }
    }
}
