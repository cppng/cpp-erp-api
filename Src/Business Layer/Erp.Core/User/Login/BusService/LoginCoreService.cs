using SimpleSoft.Mediator;
using Microsoft.AspNetCore.Http;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response;

namespace Erp.Core.User.Login.BusService
{
    public class LoginCoreService: ILoginCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<LoginBaseResponseDto> Execute(LoginRequestDto request, CancellationToken ct)
        {
            try
            {
                return await _mediator.SendAsync(new LoginRequestCommand
                {
                    ClientId = request.ClientId,
                    ClientSecrete = request.ClientSecrete,
                    DeviceOs = request.DeviceOs,
                    DeviceId = request.DeviceId,
                    DeviceModel = request.DeviceModel,
                    DeviceType = request.DeviceType,
                    DeviceName = request.DeviceName,
                }, ct);
            }
            catch (Exception ex) {
                return new LoginBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Failed,
                    Message = "Error occured authenticating user. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false
                };
            }
        }

    }
}
