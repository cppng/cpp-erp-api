using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.User.EmpSalaryUpdate.BusService
{
    public interface IEmpSalaryUpdateCoreService
    {
        Task<EmpSalaryUpdateBaseResponseDto> Execute(EmpSalaryUpdateRequestDto request, CancellationToken ct);
    }
}
