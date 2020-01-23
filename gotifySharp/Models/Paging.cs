using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class Paging
    {
        public int size { get; set; }
        public int since { get; set; }
        public int limit { get; set; }
    }
}
