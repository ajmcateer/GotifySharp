using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class MessageGetModel
    {
        public MessageModel[] messages { get; set; }
        public PagingModel paging { get; set; }
    }
}
