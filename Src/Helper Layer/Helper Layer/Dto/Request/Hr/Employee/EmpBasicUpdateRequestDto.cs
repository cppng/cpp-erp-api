using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Request.Hr.Employee;

public class EmpBasicUpdateRequestDto
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string MaritalStatus { get; set; } = string.Empty;
    public string Religion { get; set; } = string.Empty;
    public string TaxIdNo { get; set; } = string.Empty;
    public string PassportNo { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
}
