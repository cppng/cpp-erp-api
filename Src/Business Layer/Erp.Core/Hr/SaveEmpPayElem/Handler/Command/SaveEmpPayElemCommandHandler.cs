using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response;
using SimpleSoft.Mediator;
using Erp.Infrastructure.Dapper.Hr.Employee.EmpPayElement;

public class SaveEmpPayElemCommandHandler : ICommandHandler<EmpPayElemCommand, EmpPayElemBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmpPayElemInfraService _empPayElemInfraService;

    public SaveEmpPayElemCommandHandler(IMediator mediator, IEmpPayElemInfraService empPayElemInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _empPayElemInfraService = empPayElemInfraService ?? throw new ArgumentNullException(nameof(empPayElemInfraService));
    }

    public async Task<EmpPayElemBaseResponseDto> HandleAsync(EmpPayElemCommand request, CancellationToken ct)
    {
        try
        {
            return await _empPayElemInfraService.SavePayElem(request, ct);
        }
        catch (Exception ex)
        {
            return new EmpPayElemBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New employee creation was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}