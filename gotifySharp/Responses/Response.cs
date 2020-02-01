using gotifySharp.Interfaces;
using gotifySharp.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public abstract class Response : IJsonResponse
    {
        private ErrorResponse errorResponse;
        public bool Success { get; set; }
        public ErrorResponse ErrorResponse
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
