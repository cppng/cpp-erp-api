using Erp.Core.Hr.ByUsername.BusService;
using Erp.Core.Hr.EmpBySlug.BusService;
using Erp.Core.Payroll.RunSalary.BusService;
using Erp.Core.User.EmpBasicUpdate.BusService;
using Erp.Core.User.EmpContactUpdate.BusService;
using Erp.Core.User.EmpDetailsUpdate.BusService;
using Erp.Core.User.EmpLoginAccess.BusService;
using Erp.Core.User.EmployeeList.BusService;
using Erp.Core.User.EmpNokUpdate.BusService;
using Erp.Core.User.EmpNokUpdate.SaveEmpPayElem;
using Erp.Core.User.EmpPayElemList.BusService;
using Erp.Core.User.EmpSalaryUpdate.BusService;
using Erp.Core.User.EmpStatutoryUpdate.BusService;
using Erp.Core.User.NewEmployee.BusService;
using Erp.Helper.Dto.Request.Hr.Payroll;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Api.Controllers.Hr
{
    [Route("api/hr/payroll")]
    [ApiController]
    public class PayrollController : BaseController
    {

        private readonly IRunSalaryCoreService _runSalaryCoreService;
        private readonly IPayslipCoreService _payslipCoreService;

        public PayrollController(
            IRunSalaryCoreService runSalaryCoreService,
            IPayslipCoreService payslipCoreService
        )
        {
            _runSalaryCoreService = runSalaryCoreService ?? throw new ArgumentNullException(nameof(runSalaryCoreService));
            _payslipCoreService = payslipCoreService ?? throw new ArgumentNullException(nameof(payslipCoreService));
        }

        [HttpPost("run-salary")]
        public async Task<IActionResult> RunSalary(RunSalaryRequestDto request, CancellationToken ct) => Response(await _runSalaryCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("payslip")]
        public async Task<IActionResult> GetPayslip(PayslipRequestDto request, CancellationToken ct) => Response(await _payslipCoreService.Execute(request, ct).ConfigureAwait(false));

    }
}
