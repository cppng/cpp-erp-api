using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.DbServices.User.Login
{
    public interface ILoginInfraService
    {
        Task<LoginBaseResponseDto> AuthenticateUser(LoginRequestCommand request, CancellationToken ct);
    }
}
