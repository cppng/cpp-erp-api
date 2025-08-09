using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.Hr;

[Table("tbl_HR_Employee")]
public class EmployeeEntity : BaseEntity
{
    public long Id { get; set; }
    public string Slug { get; set; } = string.Empty;
    public string? Title { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Photo { get; set; } = string.Empty;
    public string? Gender { get; set; } = string.Empty;
    public string? MaritalStatus { get; set; } = string.Empty;
    public string? Religion { get; set; } = string.Empty;
    public string? TaxId { get; set; } = string.Empty;
    public string? PassportNo { get; set; } = string.Empty;
}
