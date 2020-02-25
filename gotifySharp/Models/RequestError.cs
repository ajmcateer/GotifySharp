using System;
using System.Collections.Generic;

using System.Globalization;
using gotifySharp.Interfaces;
using gotifySharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace gotifySharp.Models
{
    public class RequestError
    {
        [JsonProperty("error", Required = Required.Always)]
        public string Error { get; set; }

        [JsonProperty("errorCode", Required = Required.Always)]
        public long ErrorCode { get; set; }

        [JsonProperty("errorDescription", Required = Required.Always)]
        public string ErrorDescription { get; set; }
    }
}
