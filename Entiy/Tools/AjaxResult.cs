using System;
using System.Collections.Generic;
using System.Text;

namespace Entiy.Tools
{
     public class AjaxResult
    {
        public int code { get; set; } = 0;

        public string Msg { get; set; } = "失败";

        public bool Ses { get; set; }

        public object Data { get; set; }
        
        
    }
}
