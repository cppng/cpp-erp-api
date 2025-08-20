using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response;
using SimpleSoft.Mediator;
using Erp.Infrastructure.Dapper.Hr.Employee.EmployeeUpdate;

public class EmpLoginAccessCommandHandler : ICommandHandler<EmpLoginAccessCommand, EmpLoginAccessBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmployeeUpdateInfraService _employeeUpdateInfraService;

    public EmpLoginAccessCommandHandler(IMediator mediator, IEmployeeUpdateInfraService employeeUpdateInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _employeeUpdateInfraService = employeeUpdateInfraService ?? throw new ArgumentNullException(nameof(employeeUpdateInfraService));
    }

    public async Task<EmpLoginAccessBaseResponseDto> HandleAsync(EmpLoginAccessCommand request, CancellationToken ct)
    {
        try
        {
            return await _employeeUpdateInfraService.EmployeeLoginAccess(request, ct);
        }
        catch (Exception ex)
        {
            return new EmpLoginAccessBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}