using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.Hr.EmpBySlug.BusService
{
    public interface IEmpBySlugCoreService
    {
        Task<EmployeeDetailsBaseResponseDto> Execute(string slug, CancellationToken ct);
    }
}

