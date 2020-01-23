using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class GetMessage
    {
        public MessageModel[] messages { get; set; }
        public Paging paging { get; set; }
    }
}
