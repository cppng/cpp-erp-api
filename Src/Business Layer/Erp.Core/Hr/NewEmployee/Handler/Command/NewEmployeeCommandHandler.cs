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

namespace Erp.Core.User.NewEmployee.Handler.Command;

public class NewEmployeeCommandHandler : ICommandHandler<NewEmployeeCommand, NewEmployeeBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly INewEmployeeInfraService _newEmployeeInfraService;

    public NewEmployeeCommandHandler(IMediator mediator, INewEmployeeInfraService newEmployeeInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _newEmployeeInfraService = newEmployeeInfraService ?? throw new ArgumentNullException(nameof(newEmployeeInfraService));
    }

    public async Task<NewEmployeeBaseResponseDto> HandleAsync(NewEmployeeCommand request, CancellationToken ct)
    {
        try
        {
            return await _newEmployeeInfraService.CreateEmployee(request, ct);
        }
        catch (Exception ex)
        {
            return new NewEmployeeBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
