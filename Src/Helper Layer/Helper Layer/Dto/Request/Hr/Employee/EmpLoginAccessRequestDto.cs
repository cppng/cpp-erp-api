using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Request.Hr.Employee;

public class EmpLoginAccessRequestDto
{
    public string Slug { get; set; } = string.Empty;
    public string EmployeeUsername { get; set; } = string.Empty;
}
