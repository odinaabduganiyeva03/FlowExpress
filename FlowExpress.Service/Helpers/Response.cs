using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowExpress.Service.Helpers
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public T FValue { get; set; }
    }
}
