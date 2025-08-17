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
    public string? Phone { get; set; } = string.Empty;
    public string? Phone2 { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public string? Email2 { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? Address2 { get; set; } = string.Empty;
    public string? State { get; set; } = string.Empty;
    public string? Country { get; set; } = string.Empty;
    public string? NokName { get; set; } = string.Empty;
    public string? NokGender { get; set; } = string.Empty;
    public string? NokEmail { get; set; } = string.Empty;
    public string? NokPhone { get; set; } = string.Empty;
    public string? NokAddress { get; set; } = string.Empty;
    public string? NokAge { get; set; } = string.Empty;
    public string? NokRelationship { get; set; } = string.Empty;
    public string? EmploymentId { get; set; } = string.Empty;
    public string? JobTitle { get; set; } = string.Empty;
    public string? Organization { get; set; } = string.Empty;
    public string? Department { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
    public string? EmploymentType { get; set; } = string.Empty;
    public string? EmploymentStatus { get; set; } = string.Empty;
    public DateTime? JoinedDate { get; set; }
    public DateTime? ProbationEndDate { get; set; }
    public DateTime? ContractStartDate { get; set; }
    public DateTime? ContractEndDate { get; set; }
    public string? Supervisor { get; set; } = string.Empty;
    public string? Grade { get; set; } = string.Empty;
    public string? Category { get; set; } = string.Empty;
    public decimal? BasicSalary { get; set; }
    public string? SalaryGrade { get; set; } = string.Empty;
    public string? PayFrequncy { get; set; } = string.Empty;
    public string? BankName { get; set; } = string.Empty;
    public string? BankAccountNo { get; set; } = string.Empty;
    public string? BankAccountName { get; set; } = string.Empty;
    public string? Tin { get; set; } = string.Empty;
    public string? Pfa { get; set; } = string.Empty;
    public string? PensionNo { get; set; } = string.Empty;
    public string? Nhf { get; set; } = string.Empty;
    public string? Nsitf { get; set; } = string.Empty;
    public string? Nhis { get; set; } = string.Empty;
    public string? EmployeeUsername { get; set; } = string.Empty;
    public DateTime? EntryDate { get; set; }
}
