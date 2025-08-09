using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.User.UserListing.BusService
{
    public interface IUserListingCoreService
    {
        Task<UserListingBaseResponseDto> Execute(CancellationToken ct);
    }
}

