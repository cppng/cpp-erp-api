using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Commands.Hr.Employee
{
    public class EmpDetailsUpdateCommand : Command<EmpDetailsUpdateBaseResponseDto>
    {
        public string Slug { get; set; } = string.Empty;
        public string EmploymentId { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Organization { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string EmploymentType { get; set; } = string.Empty;
        public string EmploymentStatus { get; set; } = string.Empty;
        public string JoinedDate { get; set; } = string.Empty;
        public string ProbationEndDate { get; set; } = string.Empty;
        public string ContractStartDate { get; set; } = string.Empty;
        public string ContractEndDate { get; set; } = string.Empty;
        public string Supervisor { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
    }
}
