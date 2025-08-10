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
    public class EmpPayElemCommand : Command<EmpPayElemBaseResponseDto>
    {
        public long Id { get; set; }
        public string EmployeeSlug { get; set; } = string.Empty;
        public string EntryType { get; set; } = string.Empty;
        public string ElementCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
    }
}
