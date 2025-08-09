using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Request.Hr.Employee;

public class EmpStatutoryUpdateRequestDto
{
    public string Slug { get; set; } = string.Empty;
    public decimal Tin { get; set; }
    public string Pfa { get; set; } = string.Empty;
    public string PensionNo { get; set; } = string.Empty;
    public string Nhf { get; set; } = string.Empty;
    public string Nsitf { get; set; } = string.Empty;
    public string Nhis { get; set; } = string.Empty;
}
