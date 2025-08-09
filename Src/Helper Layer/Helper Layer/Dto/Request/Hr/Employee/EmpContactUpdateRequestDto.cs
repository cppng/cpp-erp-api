using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Request.Hr.Employee;

public class EmpContactUpdateRequestDto
{
    public string Slug { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Phone2 { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Email2 { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Address2 { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}
