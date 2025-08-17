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
using Erp.Core.User.UserListing.Handler.Queries;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Infrastructure.DbServices.Hr.Employee;
using Erp.Core.Hr.EmpBySlug.Handler.Queries;

namespace Erp.Core.Hr.EmpBySlug.Handler.Command;

public class EmpBySlugHandler : IQueryHandler<EmpBySlugQueryRequest, EmployeeDetailsBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IEmployeeInfraService _employeeInfraService;

    public EmpBySlugHandler(IMediator mediator, IEmployeeInfraService employeeInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _employeeInfraService = employeeInfraService ?? throw new ArgumentNullException(nameof(employeeInfraService));
    }

    public async Task<EmployeeDetailsBaseResponseDto> HandleAsync(EmpBySlugQueryRequest request, CancellationToken ct)
    {
        try
        {
            return await _employeeInfraService.GetEmployeeBySlug(request.Slug, request.Username, ct);
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
