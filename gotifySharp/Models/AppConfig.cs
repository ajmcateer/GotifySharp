using gotifySharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class AppConfig : IConfig
    {
        private IExtendedHttpClient _extendedHttpClient;
        private IExtendedHttpClient _tokenHttpClient;

        public string userName { get; set; }
        public string password { get; set; }
        public string url { get; set; }
        public int port { get; set; }
        private string protocol { get; set; }
        private string base64Auth { get; set; }
        public IExtendedHttpClient ExtendedHttpClient 
        {
            get
            {
                return _extendedHttpClient;
            }
            set
            {
                _extendedHttpClient = value;
            }
        }

        public IExtendedHttpClient TokenHttpClient
        {
            get
            {
                return _tokenHttpClient;
            }
            set
            {
                _tokenHttpClient = value;
            }
        }

        public AppConfig(string userName, string password, string url, int port)
        {
            this.userName = userName;
            this.password = password;
            this.url = url;
            this.port = port;

            ExtendedHttpClient = new ExtendedHttpClient(this);
            TokenHttpClient = new TokenHttpClient(this);
        }

        public Uri GetUri()
        {
            //TODO implement better logic for this ugly hack while under construction
            return new UriBuilder("http://", url.Replace("http://", ""), port).Uri;
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
