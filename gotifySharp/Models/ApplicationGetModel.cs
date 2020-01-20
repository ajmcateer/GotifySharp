using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class ApplicationGetModel
    {
        public int id { get; set; }
        public string token { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool _internal { get; set; }
        public string image { get; set; }
    }
}
