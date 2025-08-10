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
using Erp.Core.User.EmpNokUpdate.SaveEmpPayElem;

namespace Erp.Core.User.EmpNokUpdate.BusService
{
    public class SaveEmpPayElemCoreService : ISaveEmpPayElemCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public SaveEmpPayElemCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmpPayElemBaseResponseDto> Execute(EmpPayElemRequestDto request, CancellationToken ct)
        {
            try
            {
                var requestCmd = _mapper.Map<EmpPayElemRequestDto, EmpPayElemCommand>(request);
                return await _mediator.SendAsync(requestCmd, ct);
            }
            catch (Exception ex)
            {
                return new EmpPayElemBaseResponseDto
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
