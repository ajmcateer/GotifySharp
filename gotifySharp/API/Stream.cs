using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.API
{
    public class Stream
    {
        const string path = "/stream";
        ServiceProvider services;

        public Stream(ServiceProvider services)
        {
            this.services = services;
        }


    }
}
