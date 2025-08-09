using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response;
using Erp.Infrastructure.Dapper.Hr.EmployeeUpdate;
using SimpleSoft.Mediator;

public class EmpStatutoryUpdateCommandHandler : ICommandHandler<EmpStatutoryUpdateCommand, EmpStatutoryUpdateBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmployeeUpdateInfraService _employeeUpdateInfraService;

    public EmpStatutoryUpdateCommandHandler(IMediator mediator, IEmployeeUpdateInfraService employeeUpdateInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _employeeUpdateInfraService = employeeUpdateInfraService ?? throw new ArgumentNullException(nameof(employeeUpdateInfraService));
    }

    public async Task<EmpStatutoryUpdateBaseResponseDto> HandleAsync(EmpStatutoryUpdateCommand request, CancellationToken ct)
    {
        try
        {
            return await _employeeUpdateInfraService.EmployeeStatutoryUpdate(request, ct);
        }
        catch (Exception ex)
        {
            return new EmpStatutoryUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}