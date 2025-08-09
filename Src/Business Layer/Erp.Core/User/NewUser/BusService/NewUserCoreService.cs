using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;

namespace Erp.Core.User.NewUser.BusService
{
    public class NewUserCoreService: INewUserCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public NewUserCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<NewUserBaseResponseDto> Execute(NewUserRequestDto request, CancellationToken ct)
        {
            try
            {

                var requestCmd = _mapper.Map<NewUserRequestDto, NewUserRequestCommand>(request);

                return await _mediator.SendAsync(requestCmd, ct);
            }
            catch (Exception ex)
            {
                return new NewUserBaseResponseDto
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
