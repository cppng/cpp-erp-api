using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;

namespace Erp.Core.User.Role.BusService
{
    public class RoleCoreService: IRoleCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public RoleCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RoleBaseResponseDto> Execute(RoleRequestDto request, CancellationToken ct)
        {
            try
            {

                return await _mediator.SendAsync(new RoleRequestCommand
                {
                    Name = request.Name
                }, ct);
            }
            catch (Exception ex)
            {
                return new RoleBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Failed,
                    Message = "Error occured creating role. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false
                };
            }
        }
    }
}
