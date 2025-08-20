using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response;
using SimpleSoft.Mediator;
using Erp.Infrastructure.Dapper.Hr.Employee.EmployeeUpdate;

public class EmpBasicUpdateCommandHandler : ICommandHandler<EmpBasicUpdateCommand, EmpBasicUpdateBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmployeeUpdateInfraService _employeeUpdateInfraService;

    public EmpBasicUpdateCommandHandler(IMediator mediator, IEmployeeUpdateInfraService employeeUpdateInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _employeeUpdateInfraService = employeeUpdateInfraService ?? throw new ArgumentNullException(nameof(employeeUpdateInfraService));
    }

    public async Task<EmpBasicUpdateBaseResponseDto> HandleAsync(EmpBasicUpdateCommand request, CancellationToken ct)
    {
        try
        {
            return await _employeeUpdateInfraService.BasicInfoUpdate(request, ct);
        }
        catch (Exception ex)
        {
            return new EmpBasicUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}