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
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Infrastructure.Dapper.Hr.Payroll.Salary;

namespace Erp.Core.Payroll.RunSalary.Handler.Command;

public class PayslipCommandHandler : ICommandHandler<PayslipCommand, PayslipBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly ISalaryInfraService _salaryInfraService;

    public PayslipCommandHandler(IMediator mediator, ISalaryInfraService salaryInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _salaryInfraService = salaryInfraService ?? throw new ArgumentNullException(nameof(salaryInfraService));
    }

    public async Task<PayslipBaseResponseDto> HandleAsync(PayslipCommand request, CancellationToken ct)
    {
        try
        {
            return await _salaryInfraService.GetPayslip(request, ct);
        }
        catch (Exception ex)
        {
            return new PayslipBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
