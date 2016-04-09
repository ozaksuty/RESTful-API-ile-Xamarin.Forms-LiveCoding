using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApi.Models
{
    public class MobileResult
    {
        public bool Result { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
