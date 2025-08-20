using Erp.Helper.Commands.Hr.Payroll;
using Erp.Helper.Dto.Response.Hr.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Dapper.Hr.Payroll.RunSalary
{
    public interface IRunSalaryInfraService
    {
        Task<RunSalaryBaseResponseDto> RunSalary(RunSalaryCommand request, CancellationToken ct);
    }
}
