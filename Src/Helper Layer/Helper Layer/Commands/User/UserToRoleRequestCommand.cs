using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Commands.User
{
    public class UserToRoleRequestCommand : Command<UserToRoleBaseResponseDto>
    {
        public string Username { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }
}
