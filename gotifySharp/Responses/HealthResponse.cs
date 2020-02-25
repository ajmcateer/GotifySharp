using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class HealthResponse : Response
    {
        private Models.Health healthResponse;

        public HealthResponse(bool success, Models.Health healthResponse)
        {
            this.healthResponse = healthResponse;
            this.Success = success;
        }

        public HealthResponse(bool success, RequestError errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public Models.Health Health
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return healthResponse;
                }
            }
            set
            {
                healthResponse = value;
            }
        }
    }
}
