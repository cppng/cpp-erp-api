using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.User;
using Erp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.DbServices.User.Login
{
    public class LoginInfraService: ILoginInfraService
    {
        private readonly ErpDbContext _context;

        public LoginInfraService(ErpDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<LoginBaseResponseDto> AuthenticateUser(LoginRequestCommand request, CancellationToken ct)
        {
            try
            {
                var user = _context.UserEntities.SingleOrDefault(x => x.Username == request.ClientId);

                return new LoginBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Success,
                    Message = "Success",
                    StatusCode = HttpResponseCode.Success,
                    Success = true,
                    data = new LoginResponseDto
                    {
                        Name = user.Name,
                        Username = user.Username,
                    }
                };
            }
            catch (Exception ex) {
                return new LoginBaseResponseDto
                {
                    ResponseCode = AppResponseCode.InternalError,
                    Message = "Login was not successful. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                };
            }
        }
    }
}
