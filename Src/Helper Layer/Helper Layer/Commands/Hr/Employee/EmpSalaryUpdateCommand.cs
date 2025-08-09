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
    public class EmpSalaryUpdateCommand : Command<EmpSalaryUpdateBaseResponseDto>
    {
        public string Slug { get; set; } = string.Empty;
        public decimal BasicSalary { get; set; }
        public string SalaryGrade { get; set; } = string.Empty;
        public string Frequncy { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string BankAccountNo { get; set; } = string.Empty;
        public string BankAccountName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
    }
}
