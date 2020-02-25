using gotifySharp.Models;
using gotifySharp.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Interfaces
{
    public interface IJsonResponse
    {
        public bool Success { get; set; }

        public RequestError ErrorResponse { get; set; }
    }
}
