﻿using System;
using System.Collections.Generic;
using System.Text;

namespace gotifySharp.Models
{
    public class SendMessage
    {
        public string message { get; set; }
        public string title { get; set; }
        public int priority { get; set; }
    }
}
