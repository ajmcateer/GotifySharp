using gotifySharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class AppConfig : IConfig
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public int port { get; set; }
        public string protocol { get; set; }
        public string path { get; set; }
        private string base64Auth { get; set; }

        public AppConfig(string userName, string password, string url, int port, string protocol, string path)
        {
            this.userName = userName;
            this.password = password;
            this.url = url;
            this.port = port;
            this.protocol = protocol;
            this.path = path;
        }

        public Uri GetUri()
        {
            //TODO implement better logic for this ugly hack while under construction
            if(protocol == "Http")
            {
                return new UriBuilder("http://", url, port, path).Uri;
            }
            else
            {
                return new UriBuilder("https://", url, port, path).Uri;
            }
        }

        public string GetBase64Auth()
        {
            string unEncodedText = userName + ":" + password;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(unEncodedText);
            base64Auth = System.Convert.ToBase64String(plainTextBytes);
            return base64Auth;
        }
    }
}
