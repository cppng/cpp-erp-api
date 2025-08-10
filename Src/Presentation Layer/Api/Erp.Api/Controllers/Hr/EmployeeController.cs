using Erp.Core.User.EmpBasicUpdate.BusService;
using Erp.Core.User.EmpContactUpdate.BusService;
using Erp.Core.User.EmpDetailsUpdate.BusService;
using Erp.Core.User.EmployeeList.BusService;
using Erp.Core.User.EmpNokUpdate.BusService;
using Erp.Core.User.EmpNokUpdate.SaveEmpPayElem;
using Erp.Core.User.EmpSalaryUpdate.BusService;
using Erp.Core.User.EmpStatutoryUpdate.BusService;
using Erp.Core.User.NewEmployee.BusService;
using Erp.Helper.Dto.Request.Hr.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Api.Controllers.User
{
    [Route("api/hr/employee")]
    [ApiController]
    public class EmployeeController : BaseController
    {

        private readonly INewEmployeeCoreService _newEmployeeCoreService;
        private readonly IEmployeeListCoreService _employeeListCoreService;
        private readonly IEmpBasicUpdateCoreService _empBasicUpdateCoreService;
        private readonly IEmpContactUpdateCoreService _empContactUpdateCoreService;
        private readonly IEmpNokUpdateCoreService _empNokUpdateCoreService;
        private readonly IEmpDetailsUpdateCoreService _empDetailsUpdateCoreService;
        private readonly IEmpSalaryUpdateCoreService _empSalaryUpdateCoreService;
        private readonly IEmpStatutoryUpdateCoreService _empStatutoryUpdateCoreService;
        private readonly ISaveEmpPayElemCoreService _saveEmpPayElemCoreService;

        public EmployeeController(
            INewEmployeeCoreService newEmployeeCoreService,
            IEmployeeListCoreService employeeListCoreService,
            IEmpBasicUpdateCoreService empBasicUpdateCoreService,
            IEmpContactUpdateCoreService empContactUpdateCoreService,
            IEmpNokUpdateCoreService empNokUpdateCoreService,
            IEmpDetailsUpdateCoreService empDetailsUpdateCoreService,
            IEmpSalaryUpdateCoreService empSalaryUpdateCoreService,
            IEmpStatutoryUpdateCoreService empStatutoryUpdateCoreService,
            ISaveEmpPayElemCoreService saveEmpPayElemCoreService
        )
        {
            _newEmployeeCoreService = newEmployeeCoreService ?? throw new ArgumentNullException(nameof(newEmployeeCoreService));
            _employeeListCoreService = employeeListCoreService ?? throw new ArgumentNullException(nameof(employeeListCoreService));
            _empBasicUpdateCoreService = empBasicUpdateCoreService ?? throw new ArgumentNullException(nameof(empBasicUpdateCoreService));
            _empContactUpdateCoreService = empContactUpdateCoreService ?? throw new ArgumentNullException(nameof(empContactUpdateCoreService));
            _empNokUpdateCoreService = empNokUpdateCoreService ?? throw new ArgumentNullException(nameof(empNokUpdateCoreService));
            _empDetailsUpdateCoreService = empDetailsUpdateCoreService ?? throw new ArgumentNullException(nameof(empDetailsUpdateCoreService));
            _empSalaryUpdateCoreService = empSalaryUpdateCoreService ?? throw new ArgumentNullException(nameof(empSalaryUpdateCoreService));
            _empStatutoryUpdateCoreService = empStatutoryUpdateCoreService ?? throw new ArgumentNullException(nameof(empStatutoryUpdateCoreService));
            _saveEmpPayElemCoreService = saveEmpPayElemCoreService ?? throw new ArgumentNullException(nameof(saveEmpPayElemCoreService));
        }

        [HttpPost("create-new-employee")]
        public async Task<IActionResult> NewEmployee([FromBody] NewEmployeeRequestDto request, CancellationToken ct) => Response(await _newEmployeeCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("employee-list")]
        public async Task<IActionResult> Employees([FromBody] EmployeesRequestDto request, CancellationToken ct) => Response(await _employeeListCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("emp-basic-info-update")]
        public async Task<IActionResult> EmpBasicUpdate([FromBody] EmpBasicUpdateRequestDto request, CancellationToken ct) => Response(await _empBasicUpdateCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("emp-contact-update")]
        public async Task<IActionResult> EmpContactUpdate([FromBody] EmpContactUpdateRequestDto request, CancellationToken ct) => Response(await _empContactUpdateCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("emp-next-of-kin-update")]
        public async Task<IActionResult> EmpNokUpdate([FromBody] EmpNokUpdateRequestDto request, CancellationToken ct) => Response(await _empNokUpdateCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("emp-details-update")]
        public async Task<IActionResult> EmpDetailsUpdate([FromBody] EmpDetailsUpdateRequestDto request, CancellationToken ct) => Response(await _empDetailsUpdateCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("emp-salary-update")]
        public async Task<IActionResult> EmpSalaryUpdate([FromBody] EmpSalaryUpdateRequestDto request, CancellationToken ct) => Response(await _empSalaryUpdateCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("emp-statutory-update")]
        public async Task<IActionResult> EmpStatutoryUpdate([FromBody] EmpStatutoryUpdateRequestDto request, CancellationToken ct) => Response(await _empStatutoryUpdateCoreService.Execute(request, ct).ConfigureAwait(false));
        
        [HttpPost("emp-save-pay-elem")]
        public async Task<IActionResult> EmpSavePayElem([FromBody] EmpPayElemRequestDto request, CancellationToken ct) => Response(await _saveEmpPayElemCoreService.Execute(request, ct).ConfigureAwait(false));

    }
}
