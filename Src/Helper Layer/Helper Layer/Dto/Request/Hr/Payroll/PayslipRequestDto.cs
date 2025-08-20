using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Request.Hr.Payroll;

public class PayslipRequestDto
{
    public string Username { get; set; } = string.Empty;
    public int Month { get; set; }
}
