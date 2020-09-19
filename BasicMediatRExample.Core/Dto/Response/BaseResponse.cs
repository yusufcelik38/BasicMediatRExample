using System;
using System.Collections.Generic;
using System.Text;

namespace BasicMediatRExample.Core.Dto.Response
{
    public class BaseResponse<T>
    {
        public bool IsSuccessful { get; set; } = true;
        public string ReturnMessage { get; set; }
        public T PayLoad { get; set; }
    }
}
