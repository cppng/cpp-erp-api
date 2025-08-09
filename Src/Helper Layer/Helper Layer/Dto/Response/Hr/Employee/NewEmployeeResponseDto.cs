using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response.Hr.Employee
{
    public class NewEmployeeResponseDto
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
    }

    public class NewEmployeeBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public NewEmployeeResponseDto data { get; set; } = new NewEmployeeResponseDto();
    }
}
