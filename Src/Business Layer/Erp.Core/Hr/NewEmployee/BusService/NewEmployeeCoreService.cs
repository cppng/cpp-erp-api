using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;
using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Commands.Hr.Employee;

namespace Erp.Core.User.NewEmployee.BusService
{
    public class NewEmployeeCoreService : INewEmployeeCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public NewEmployeeCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<NewEmployeeBaseResponseDto> Execute(NewEmployeeRequestDto request, CancellationToken ct)
        {
            try
            {
                return await _mediator.SendAsync(new NewEmployeeCommand
                {
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName
                }, ct);
            }
            catch (Exception ex)
            {
                return new NewEmployeeBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Failed,
                    Message = "Error occured create new employee. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false
                };
            }
        }
    }
}
