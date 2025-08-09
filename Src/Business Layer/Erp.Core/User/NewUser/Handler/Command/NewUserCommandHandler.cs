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

namespace Erp.Core.User.NewUser.Handler.Command;

public class NewUserCommandHandler : ICommandHandler<NewUserRequestCommand, NewUserBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IUserManagementInfraService _userManagementInfraService;

    public NewUserCommandHandler(IMediator mediator, IUserManagementInfraService userManagementInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _userManagementInfraService = userManagementInfraService ?? throw new ArgumentNullException(nameof(userManagementInfraService));
    }

    public async Task<NewUserBaseResponseDto> HandleAsync(NewUserRequestCommand request, CancellationToken ct)
    {
        try
        {
            return await _userManagementInfraService.NewUser(request, ct);
        }
        catch (Exception ex)
        {
            return new NewUserBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New user registration was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
