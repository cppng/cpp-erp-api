using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;
using Erp.Core.User.UserListing.Handler.Queries;
using Erp.Domain.Entities;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Domain.Entities.Hr;
using Erp.Core.User.ByUsername.Handler.Queries;

namespace Erp.Core.Hr.ByUsername.BusService
{
    public class EmpByUsernameCoreService : IEmpByUsernameCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public EmpByUsernameCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmployeeDetailsBaseResponseDto> Execute(string username, CancellationToken ct)
        {
            try
            {
                return await _mediator.FetchAsync(new EmpByUsernameQueryRequest
                {
                    Username = username
                }, ct);
            }
            catch (Exception ex)
            {
                return new EmployeeDetailsBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Failed,
                    Message = "Error occured authenticating user. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                    data = new EmployeeEntity()
                };
            }
        }
    }
}
