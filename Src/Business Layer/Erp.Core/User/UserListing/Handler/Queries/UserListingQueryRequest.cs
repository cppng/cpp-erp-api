using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.User.UserListing.Handler.Queries
{
    public class UserListingQueryRequest: Query<UserListingBaseResponseDto>
    {
        public string Username { get; set; } = string.Empty;
    }
}
