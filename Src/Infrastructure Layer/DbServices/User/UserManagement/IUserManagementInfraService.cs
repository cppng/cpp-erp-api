using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.DbServices.User.UserManagement;

public interface IUserManagementInfraService
{
    Task<NewUserBaseResponseDto> NewUser(NewUserRequestCommand request, CancellationToken ct);
    Task<UserListingBaseResponseDto> GetUsers(string username, CancellationToken ct);
}
