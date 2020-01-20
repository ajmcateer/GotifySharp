using gotifySharp.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace gotifySharp.Interfaces
{
    public interface IExtendedHttpClient
    {
        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
