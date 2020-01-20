using System;
using System.Collections.Generic;

using System.Globalization;
using gotifySharp.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace gotifySharp.Responses
{

    public class ClientModel
    {
        [JsonProperty("id", Required = Required.Always)]
        public long Id { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("token", Required = Required.Always)]
        public string Token { get; set; }
    }
}