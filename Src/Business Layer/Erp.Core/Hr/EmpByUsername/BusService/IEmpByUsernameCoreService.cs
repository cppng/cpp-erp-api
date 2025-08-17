using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.Hr.ByUsername.BusService
{
    public interface IEmpByUsernameCoreService
    {
        Task<EmployeeDetailsBaseResponseDto> Execute(string username, CancellationToken ct);
    }
}

