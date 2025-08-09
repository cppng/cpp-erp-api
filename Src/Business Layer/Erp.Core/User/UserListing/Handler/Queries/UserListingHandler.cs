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

namespace Erp.Core.User.NewUser.Handler.Command;

public class UserListingHandler : IQueryHandler<UserListingQueryRequest, UserListingBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly IUserManagementInfraService _userManagementInfraService;

    public UserListingHandler(IMediator mediator, IUserManagementInfraService userManagementInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _userManagementInfraService = userManagementInfraService ?? throw new ArgumentNullException(nameof(userManagementInfraService));
    }

    public async Task<UserListingBaseResponseDto> HandleAsync(UserListingQueryRequest request, CancellationToken ct)
    {
        try
        {
            return await _userManagementInfraService.GetUsers(request.Username, ct);
        }
        catch (Exception ex)
        {
            return new UserListingBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "New user registration was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
