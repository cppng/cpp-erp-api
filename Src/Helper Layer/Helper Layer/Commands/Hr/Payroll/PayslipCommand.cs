using Erp.Helper.Dto.Response.Hr.Employee;
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
    public class PayslipCommand : Command<PayslipBaseResponseDto>
    {
        public string Username { get; set; } = string.Empty;
        public int Month { get; set; }
        public string Tenant { get; set; } = string.Empty;
    }
}
