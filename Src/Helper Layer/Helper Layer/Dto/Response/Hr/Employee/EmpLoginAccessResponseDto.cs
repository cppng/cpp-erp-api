using Erp.Domain.Entities.Hr;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response.Hr.Employee
{
    public class EmpLoginAccessResponseDto
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
    }

    public class EmpLoginAccessBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public EmpLoginAccessResponseDto data { get; set; } = new EmpLoginAccessResponseDto();
    }
}
