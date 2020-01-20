using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class ClientGetModel
    {

        public class Rootobject
        {
            public Class1[] Property1 { get; set; }
        }

        public class Class1
        {
            public int id { get; set; }
            public string token { get; set; }
            public string name { get; set; }
        }
    }
}
