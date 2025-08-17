using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp.Infrastructure.DbServices.User.NewUser;
using Erp.Infrastructure.DbServices.User.UserManagement;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Infrastructure.Dapper.Hr.NewEmployee;
using Erp.Infrastructure.DbServices.Hr.Employee;

namespace Erp.Core.User.EmployeeList.Handler.Command;

public class EmpPayElemListCommandHandler : ICommandHandler<EmpPayElemListCommand, EmpPayElemListBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmployeeInfraService _employeeInfraService;

    public EmpPayElemListCommandHandler(IMediator mediator, IEmployeeInfraService employeeInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _employeeInfraService = employeeInfraService ?? throw new ArgumentNullException(nameof(employeeInfraService));
    }

    public async Task<EmpPayElemListBaseResponseDto> HandleAsync(EmpPayElemListCommand request, CancellationToken ct)
    {
        try
        {
            return await _employeeInfraService.GetEmpPayElemList(request, ct);
        }
        catch (Exception ex)
        {
            return new EmpPayElemListBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
