using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response.Hr.Employee
{
    public class PayslipResponseDto
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string PayGrade { get; set; } = string.Empty;
        public List<ProcessedSalaryResponseDto> PayElements { get; set; } = new List<ProcessedSalaryResponseDto>();
    }

    public class PayslipBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public PayslipResponseDto data { get; set; } = new PayslipResponseDto();
    }
}
