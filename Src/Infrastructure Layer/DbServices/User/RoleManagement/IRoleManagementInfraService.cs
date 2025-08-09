using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.DbServices.User.RoleManagement;

public interface IRoleManagementInfraService
{
    Task<RoleBaseResponseDto> CreateRole(RoleRequestCommand request, CancellationToken ct);
    Task<UserToRoleBaseResponseDto> AddUserToRole(UserToRoleRequestCommand request, CancellationToken ct);
    Task<RoleListingBaseResponseDto> GetRoles(string username, CancellationToken ct);
}
