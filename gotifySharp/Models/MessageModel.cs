using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public int Appid { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        //public string[] extras { get; set; }
        public DateTime Date { get; set; }
    }
}
