using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class ErrorCustomModel
    {
        public bool Succeeded { get; set; } = true;
        public int? ErrorCode { get; set; }

        public string ErrorMsg { get; set; }
    }
}
