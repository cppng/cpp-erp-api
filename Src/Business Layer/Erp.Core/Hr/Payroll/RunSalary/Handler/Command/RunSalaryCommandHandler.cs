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
using Erp.Helper.Dto.Response.Hr.Payroll;
using Erp.Helper.Commands.Hr.Payroll;
using Erp.Infrastructure.Dapper.Hr.Payroll.RunSalary;

namespace Erp.Core.Payroll.RunSalary.Handler.Command;

public class RunSalaryCommandHandler : ICommandHandler<RunSalaryCommand, RunSalaryBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IRunSalaryInfraService _runSalaryInfraService;

    public RunSalaryCommandHandler(IMediator mediator, IRunSalaryInfraService runSalaryInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _runSalaryInfraService = runSalaryInfraService ?? throw new ArgumentNullException(nameof(runSalaryInfraService));
    }

    public async Task<RunSalaryBaseResponseDto> HandleAsync(RunSalaryCommand request, CancellationToken ct)
    {
        try
        {
            return await _runSalaryInfraService.RunSalary(request, ct);
        }
        catch (Exception ex)
        {
            return new RunSalaryBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
