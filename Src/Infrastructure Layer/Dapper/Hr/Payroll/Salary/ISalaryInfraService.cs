using Erp.Helper.Commands.Hr.Payroll;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Dapper.Hr.Payroll.Salary
{
    public interface ISalaryInfraService
    {
        Task<PayslipBaseResponseDto> GetPayslip(PayslipCommand request, CancellationToken ct);
    }
}
