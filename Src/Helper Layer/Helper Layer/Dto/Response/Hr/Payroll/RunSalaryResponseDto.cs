using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response.Hr.Payroll
{
    public class RunSalaryResponseDto
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
    }

    public class RunSalaryBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public RunSalaryResponseDto data { get; set; } = new RunSalaryResponseDto();
    }
}
