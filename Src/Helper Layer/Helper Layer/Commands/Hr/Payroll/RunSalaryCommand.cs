using Erp.Helper.Dto.Response.Hr.Payroll;
using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Commands.Hr.Payroll
{
    public class RunSalaryCommand : Command<RunSalaryBaseResponseDto>
    {
        public int Month { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
    }
}
