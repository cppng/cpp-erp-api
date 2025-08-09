using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Request.Hr.Employee;

public class EmpSalaryUpdateRequestDto
{
    public string Slug { get; set; } = string.Empty;
    public decimal BasicSalary { get; set; }
    public string SalaryGrade { get; set; } = string.Empty;
    public string Frequncy { get; set; } = string.Empty;
    public string BankName { get; set; } = string.Empty;
    public string BankAccountNo { get; set; } = string.Empty;
    public string BankAccountName { get; set; } = string.Empty;
}
