using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.Hr;

[Table("tbl_HR_Employee_Pay_Element")]
public class EmpPayElemEntity : BaseEntity
{
    public long Id { get; set; }
    public string EmployeeSlug { get; set; } = string.Empty;
    public string EntryType { get; set; } = string.Empty;
    public string ElementCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
