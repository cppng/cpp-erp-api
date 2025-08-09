using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.User;
using Erp.Infrastructure.DbServices.User.Login;
using Microsoft.EntityFrameworkCore;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.User.Login.Handler.Command;

public class LoginCommandHandler: ICommandHandler<LoginRequestCommand, LoginBaseResponseDto>
{
    private readonly IMediator _mediator;
    private readonly ILoginInfraService _loginInfraService;

    public LoginCommandHandler(IMediator mediator, ILoginInfraService loginInfraService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _loginInfraService = loginInfraService ?? throw new ArgumentNullException(nameof(loginInfraService));
    }

    public async Task<LoginBaseResponseDto> HandleAsync(LoginRequestCommand request, CancellationToken ct)
    {
        try
        {
            return await _loginInfraService.AuthenticateUser(request, ct);
        }
        catch (Exception ex) {
            return new LoginBaseResponseDto
            {
                ResponseCode = AppResponseCode.Failed,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false
            };
        }
    }
}
