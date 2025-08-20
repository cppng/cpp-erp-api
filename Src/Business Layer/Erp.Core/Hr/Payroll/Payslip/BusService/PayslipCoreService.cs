using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.Dto.Response;
using Microsoft.AspNetCore.Http;
using SimpleSoft.Mediator;
using AutoMapper;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Request.Hr.Payroll;
using Erp.Helper.Dto.Response.Hr.Payroll;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Commands.Hr.Payroll;

namespace Erp.Core.Payroll.RunSalary.BusService
{
    public class PayslipCoreService : IPayslipCoreService
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public PayslipCoreService(IMediator mediator, IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PayslipBaseResponseDto> Execute(PayslipRequestDto request, CancellationToken ct)
        {
            try
            {
                return await _mediator.SendAsync(new PayslipCommand
                {
                    Month = request.Month,
                    Username = request.Username,
                    Tenant = ""
                }, ct);
            }
            catch (Exception ex)
            {
                return new PayslipBaseResponseDto
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
