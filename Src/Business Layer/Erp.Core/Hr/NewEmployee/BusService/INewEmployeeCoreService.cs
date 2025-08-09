using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.User.NewEmployee.BusService
{
    public interface INewEmployeeCoreService
    {
        Task<NewEmployeeBaseResponseDto> Execute(NewEmployeeRequestDto request, CancellationToken ct);
    }
}
