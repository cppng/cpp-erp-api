using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Erp.Infrastructure.DbServices.User.NewUser;
using Erp.Infrastructure.DbServices.User.Role;
using Erp.Infrastructure.DbServices.User.RoleManagement;

namespace Erp.Core.User.Role.Handler.Command;

public class RoleCommandHandler : ICommandHandler<RoleRequestCommand, RoleBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IRoleManagementInfraService _roleManagementInfraService;

    public RoleCommandHandler(IMediator mediator, IRoleManagementInfraService roleManagementInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _roleManagementInfraService = roleManagementInfraService ?? throw new ArgumentNullException(nameof(roleManagementInfraService));
    }

    public async Task<RoleBaseResponseDto> HandleAsync(RoleRequestCommand request, CancellationToken ct)
    {
        try
        {
            return await _roleManagementInfraService.CreateRole(request, ct);
        }
        catch (Exception ex)
        {
            return new RoleBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "Role created successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
