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
    public class NewEmployeeCommand : Command<NewEmployeeBaseResponseDto>
    {
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
    }
}
