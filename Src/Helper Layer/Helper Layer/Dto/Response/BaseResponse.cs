using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public IEnumerable<object> Errors { get; set; } = new List<object>();
    }
}
