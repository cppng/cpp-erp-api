using Erp.Helper.Dto.Response;
using SimpleSoft.Mediator;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Infrastructure.DbServices.Hr.Employee;
using Erp.Core.User.ByUsername.Handler.Queries;

namespace Erp.Core.User.ByUsername.Handler.Command;

public class EmpByUsernameHandler : IQueryHandler<EmpByUsernameQueryRequest, EmployeeDetailsBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmployeeInfraService _employeeInfraService;

    public EmpByUsernameHandler(IMediator mediator, IEmployeeInfraService employeeInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _employeeInfraService = employeeInfraService ?? throw new ArgumentNullException(nameof(employeeInfraService));
    }

    public async Task<EmployeeDetailsBaseResponseDto> HandleAsync(EmpByUsernameQueryRequest request, CancellationToken ct)
    {
        try
        {
            return await _employeeInfraService.GetEmployeeByUsername(request.Username, ct);
        }
        catch (Exception ex)
        {
            return new EmployeeDetailsBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New user registration was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
