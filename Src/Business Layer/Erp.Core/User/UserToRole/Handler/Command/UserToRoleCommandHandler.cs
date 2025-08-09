using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using SimpleSoft.Mediator;
using Erp.Infrastructure.DbServices.User.Role;
using Erp.Infrastructure.DbServices.User.RoleManagement;

namespace Erp.Core.User.NewUser.Handler.Command;

public class UserToRoleCommandHandler : ICommandHandler<UserToRoleRequestCommand, UserToRoleBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IRoleManagementInfraService _roleManagementInfraService;

    public UserToRoleCommandHandler(IMediator mediator, IRoleManagementInfraService roleManagementInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _roleManagementInfraService = roleManagementInfraService ?? throw new ArgumentNullException(nameof(roleManagementInfraService));
    }

    public async Task<UserToRoleBaseResponseDto> HandleAsync(UserToRoleRequestCommand request, CancellationToken ct)
    {
        try
        {
            return await _roleManagementInfraService.AddUserToRole(request, ct);
        }
        catch (Exception ex)
        {
            return new UserToRoleBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "User added to role successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
