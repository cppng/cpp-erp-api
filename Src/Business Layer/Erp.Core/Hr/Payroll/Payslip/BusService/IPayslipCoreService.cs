using Erp.Helper.Dto.Request.Hr.Payroll;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Payroll;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.Payroll.RunSalary.BusService
{
    public interface IPayslipCoreService
    {
        Task<PayslipBaseResponseDto> Execute(PayslipRequestDto request, CancellationToken ct);
    }
}
