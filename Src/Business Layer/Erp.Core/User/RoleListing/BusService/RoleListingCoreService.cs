using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;
using Erp.Core.User.UserListing.Handler.Queries;
using Erp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Erp.Core.User.RoleListing.BusService
{
    public class RoleListingCoreService : IRoleListingCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public RoleListingCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RoleListingBaseResponseDto> Execute(CancellationToken ct)
        {
            try
            {
                return await _mediator.FetchAsync(new RoleListingQueryRequest
                {
                    Username = ""
                }, ct);
            }
            catch (Exception ex)
            {
                return new RoleListingBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Failed,
                    Message = "Error occured authenticating user. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                    data = new List<IdentityRole>()
                };
            }
        }
    }
}
