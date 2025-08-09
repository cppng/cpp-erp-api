using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.DbServices.Hr.Employee
{
    public interface IEmployeeInfraService
    {
        Task<EmployeesBaseResponseDto> GetEmployees(EmployeesCommand request, CancellationToken ct);
    }
}
