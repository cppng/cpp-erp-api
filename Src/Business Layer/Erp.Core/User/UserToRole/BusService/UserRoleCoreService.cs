using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;

namespace Erp.Core.User.UserToRole.BusService
{
    public class UserToRoleCoreService : IUserToRoleCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserToRoleCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserToRoleBaseResponseDto> Execute(UserToRoleRequestDto request, CancellationToken ct)
        {
            try
            {
                return await _mediator.SendAsync(new UserToRoleRequestCommand
                {
                    Username = request.Username,
                    RoleName = request.RoleName
                }, ct);
            }
            catch (Exception ex)
            {
                return new UserToRoleBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Failed,
                    Message = "Error occured adding user to role. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false
                };
            }
        }
    }
}
