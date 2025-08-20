using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Dapper.Hr.Employee.EmployeeUpdate
{
    public interface IEmployeeUpdateInfraService
    {
        Task<EmpBasicUpdateBaseResponseDto> BasicInfoUpdate(EmpBasicUpdateCommand request, CancellationToken ct);
        Task<EmpContactUpdateBaseResponseDto> ContactUpdate(EmpContactUpdateCommand request, CancellationToken ct);
        Task<EmpNokUpdateBaseResponseDto> NexOfKinUpdate(EmpNokUpdateCommand request, CancellationToken ct);
        Task<EmpDetailsUpdateBaseResponseDto> EmployeeDetailsUpdate(EmpDetailsUpdateCommand request, CancellationToken ct);
        Task<EmpSalaryUpdateBaseResponseDto> EmployeeSalaryUpdate(EmpSalaryUpdateCommand request, CancellationToken ct);
        Task<EmpStatutoryUpdateBaseResponseDto> EmployeeStatutoryUpdate(EmpStatutoryUpdateCommand request, CancellationToken ct);
        Task<EmpLoginAccessBaseResponseDto> EmployeeLoginAccess(EmpLoginAccessCommand request, CancellationToken ct);
    }
}
