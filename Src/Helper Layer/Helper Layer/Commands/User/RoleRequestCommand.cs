using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Commands.User
{
    public class RoleRequestCommand : Command<RoleBaseResponseDto>
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
