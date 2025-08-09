using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;
using Erp.Core.User.UserListing.Handler.Queries;
using Erp.Domain.Entities;

namespace Erp.Core.User.UserListing.BusService
{
    public class UserListingCoreService : IUserListingCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public UserListingCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserListingBaseResponseDto> Execute(CancellationToken ct)
        {
            try
            {
                return await _mediator.FetchAsync(new UserListingQueryRequest
                {
                    Username = ""
                }, ct);
            }
            catch (Exception ex)
            {
                return new UserListingBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Failed,
                    Message = "Error occured authenticating user. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                    data = new List<UserResponseDto>()
                };
            }
        }
    }
}
