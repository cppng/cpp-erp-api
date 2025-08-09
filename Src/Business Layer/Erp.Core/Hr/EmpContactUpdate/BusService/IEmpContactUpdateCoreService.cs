using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.User.EmpContactUpdate.BusService
{
    public interface IEmpContactUpdateCoreService
    {
        Task<EmpContactUpdateBaseResponseDto> Execute(EmpContactUpdateRequestDto request, CancellationToken ct);
    }
}
