using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response;
using Erp.Infrastructure.Dapper.Hr.EmployeeUpdate;
using SimpleSoft.Mediator;

public class EmpNokUpdateCommandHandler : ICommandHandler<EmpNokUpdateCommand, EmpNokUpdateBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmployeeUpdateInfraService _employeeUpdateInfraService;

    public EmpNokUpdateCommandHandler(IMediator mediator, IEmployeeUpdateInfraService employeeUpdateInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _employeeUpdateInfraService = employeeUpdateInfraService ?? throw new ArgumentNullException(nameof(employeeUpdateInfraService));
    }

    public async Task<EmpNokUpdateBaseResponseDto> HandleAsync(EmpNokUpdateCommand request, CancellationToken ct)
    {
        try
        {
            return await _employeeUpdateInfraService.NexOfKinUpdate(request, ct);
        }
        catch (Exception ex)
        {
            return new EmpNokUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}