using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Request.Hr.Employee;

public class EmpPayElemRequestDto
{
    public long Id { get; set; }
    public string EmployeeSlug { get; set; } = string.Empty;
    public string EntryType { get; set; } = string.Empty;
    public string ElementCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
