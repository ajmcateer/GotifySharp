using gotifySharp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Responses
{
    public class VersionResponse : Response
    {
        private Models.Version versionResponse;

        public VersionResponse(bool success, Models.Version versionResponse)
        {
            this.versionResponse = versionResponse;
            this.Success = success;
        }

        public VersionResponse(bool success, ErrorResponse errorResponse)
        {
            this.ErrorResponse = errorResponse;
            this.Success = success;
        }

        public Models.Version Version
        {
            get
            {
                if (!Success)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    return versionResponse;
                }
            }
            set
            {
                versionResponse = value;
            }
        }
    }
}
