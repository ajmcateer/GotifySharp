﻿using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Interfaces
{
    public interface IConfig
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public int port { get; set; }
        IExtendedHttpClient ExtendedHttpClient { get; set; }
        IExtendedHttpClient TokenHttpClient { get; set; }
        public Uri GetUri();
        public string GetBase64Auth();
    }
}
