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
using Erp.Infrastructure.DbServices.User.RoleManagement;

namespace Erp.Core.User.NewUser.Handler.Command;

public class RoleListingHandler : IQueryHandler<RoleListingQueryRequest, RoleListingBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IRoleManagementInfraService _roleManagementInfraService;

    public RoleListingHandler(IMediator mediator, IRoleManagementInfraService roleManagementInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _roleManagementInfraService = roleManagementInfraService ?? throw new ArgumentNullException(nameof(roleManagementInfraService));
    }

    public async Task<RoleListingBaseResponseDto> HandleAsync(RoleListingQueryRequest request, CancellationToken ct)
    {
        try
        {
            return await _roleManagementInfraService.GetRoles(request.Username, ct);
        }
        catch (Exception ex)
        {
            return new RoleListingBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New user registration was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
