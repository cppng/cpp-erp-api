using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response.Hr.Employee
{
    public class ProcessedSalaryResponseDto
    {
        public int Id { get; set; }
        public int PsYear { get; set; }
        public int PsMonth { get; set; }
        public int PsDays { get; set; }
        public decimal PsAmount { get; set; }
        public string ElementName { get; set; } = string.Empty;
        public string EntryType { get; set; } = string.Empty;
        public string EmployeeSlug { get; set; } = string.Empty;
        public string ElementCode { get; set; } = string.Empty;
        public string EntryDate { get; set; } = string.Empty;
    }

    public class ProcessedSalaryBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<ProcessedSalaryResponseDto> data { get; set; } = new List<ProcessedSalaryResponseDto>();
    }
}
