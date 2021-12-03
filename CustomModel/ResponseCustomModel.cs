using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomModel
{
    public class ResponseCustomModel<T>
    {
        public ResponseCustomModel()
        {
            Error = new ErrorCustomModel();
        }

        public ErrorCustomModel Error { get; set; }

        public T Data { get; set; }
    }
}
