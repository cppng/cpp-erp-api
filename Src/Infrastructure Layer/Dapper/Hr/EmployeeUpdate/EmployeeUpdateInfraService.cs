using Dapper;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using Erp.Persistence.Dapper;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.Dapper.Hr.EmployeeUpdate;

public class EmployeeUpdateInfraService: IEmployeeUpdateInfraService
{
    private readonly IDapperService _dapperService;
    private DynamicParameters _dbParams;

    public EmployeeUpdateInfraService(IDapperService dapperService)
    {
        _dapperService = dapperService ?? throw new ArgumentNullException(nameof(dapperService));
    }

   public async Task<EmpBasicUpdateBaseResponseDto> BasicInfoUpdate(EmpBasicUpdateCommand request, CancellationToken ct)
   {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: request.Slug, direction: ParameterDirection.Input);
            _dbParams.Add("Title", dbType: DbType.String, value: request.Title, direction: ParameterDirection.Input);
            _dbParams.Add("FirstName", dbType: DbType.String, value: request.FirstName, direction: ParameterDirection.Input);
            _dbParams.Add("MiddleName", dbType: DbType.String, value: request.MiddleName, direction: ParameterDirection.Input);
            _dbParams.Add("LastName", dbType: DbType.String, value: request.LastName, direction: ParameterDirection.Input);
            _dbParams.Add("Gender", dbType: DbType.String, value: request.Gender, direction: ParameterDirection.Input);
            _dbParams.Add("MaritalStatus", dbType: DbType.String, value: request.MaritalStatus, direction: ParameterDirection.Input);
            _dbParams.Add("Religion", dbType: DbType.String, value: request.Religion, direction: ParameterDirection.Input);
            _dbParams.Add("TaxId", dbType: DbType.String, value: request.TaxIdNo, direction: ParameterDirection.Input);
            _dbParams.Add("PassportNo", dbType: DbType.String, value: request.PassportNo, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpBasicUpdateResponseDto>("proc_HR_Employee_Basic_Update", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpBasicUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new EmpBasicUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmpContactUpdateBaseResponseDto> ContactUpdate(EmpContactUpdateCommand request, CancellationToken ct)
    {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: request.Slug, direction: ParameterDirection.Input);
            _dbParams.Add("Phone", dbType: DbType.String, value: request.Phone, direction: ParameterDirection.Input);
            _dbParams.Add("Phone2", dbType: DbType.String, value: request.Phone2, direction: ParameterDirection.Input);
            _dbParams.Add("Email", dbType: DbType.String, value: request.Email, direction: ParameterDirection.Input);
            _dbParams.Add("Email2", dbType: DbType.String, value: request.Email2, direction: ParameterDirection.Input);
            _dbParams.Add("Address", dbType: DbType.String, value: request.Address, direction: ParameterDirection.Input);
            _dbParams.Add("Address2", dbType: DbType.String, value: request.Address2, direction: ParameterDirection.Input);
            _dbParams.Add("State", dbType: DbType.String, value: request.State, direction: ParameterDirection.Input);
            _dbParams.Add("Country", dbType: DbType.String, value: request.Country, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpContactUpdateResponseDto>("proc_HR_Employee_Contact_Update", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpContactUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new EmpContactUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmpNokUpdateBaseResponseDto> NexOfKinUpdate(EmpNokUpdateCommand request, CancellationToken ct)
    {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: request.Slug, direction: ParameterDirection.Input);
            _dbParams.Add("NokName", dbType: DbType.String, value: request.Name, direction: ParameterDirection.Input);
            _dbParams.Add("NokGender", dbType: DbType.String, value: request.Gender, direction: ParameterDirection.Input);
            _dbParams.Add("NokEmail", dbType: DbType.String, value: request.Email, direction: ParameterDirection.Input);
            _dbParams.Add("NokPhone", dbType: DbType.String, value: request.Phone, direction: ParameterDirection.Input);
            _dbParams.Add("NokAddress", dbType: DbType.String, value: request.Address, direction: ParameterDirection.Input);
            _dbParams.Add("NokAge", dbType: DbType.String, value: request.Age, direction: ParameterDirection.Input);
            _dbParams.Add("NokRelationship", dbType: DbType.String, value: request.Relationship, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpNokUpdateResponseDto>("proc_HR_Employee_Nok_Update", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpNokUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new EmpNokUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmpDetailsUpdateBaseResponseDto> EmployeeDetailsUpdate(EmpDetailsUpdateCommand request, CancellationToken ct)
    {
        try
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var dtFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

            DateTime? joinedDt = string.IsNullOrEmpty(request.JoinedDate)? null: DateTime.ParseExact(request.JoinedDate, dtFormat, provider);
            DateTime? probDt = string.IsNullOrEmpty(request.ProbationEndDate) ? null : DateTime.ParseExact(request.ProbationEndDate, dtFormat, provider);
            DateTime? csDt = string.IsNullOrEmpty(request.ContractStartDate) ? null : DateTime.ParseExact(request.ContractStartDate, dtFormat, provider);
            DateTime? cedDt = string.IsNullOrEmpty(request.ContractEndDate) ? null : DateTime.ParseExact(request.ContractEndDate, dtFormat, provider);

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: request.Slug, direction: ParameterDirection.Input);
            _dbParams.Add("EmploymentId", dbType: DbType.String, value: request.EmploymentId, direction: ParameterDirection.Input);
            _dbParams.Add("JobTitle", dbType: DbType.String, value: request.JobTitle, direction: ParameterDirection.Input);
            _dbParams.Add("Organization", dbType: DbType.String, value: request.Organization, direction: ParameterDirection.Input);
            _dbParams.Add("Department", dbType: DbType.String, value: request.Department, direction: ParameterDirection.Input);
            _dbParams.Add("Location", dbType: DbType.String, value: request.Location, direction: ParameterDirection.Input);
            _dbParams.Add("EmploymentType", dbType: DbType.String, value: request.EmploymentType, direction: ParameterDirection.Input);
            _dbParams.Add("EmploymentStatus", dbType: DbType.String, value: request.EmploymentStatus, direction: ParameterDirection.Input);
            _dbParams.Add("JoinedDate", dbType: DbType.String, value: joinedDt, direction: ParameterDirection.Input);
            _dbParams.Add("ProbationEndDate", dbType: DbType.String, value: probDt, direction: ParameterDirection.Input);
            _dbParams.Add("ContractStartDate", dbType: DbType.String, value: csDt, direction: ParameterDirection.Input);
            _dbParams.Add("ContractEndDate", dbType: DbType.String, value: cedDt, direction: ParameterDirection.Input);
            _dbParams.Add("Supervisor", dbType: DbType.String, value: request.Supervisor, direction: ParameterDirection.Input);
            _dbParams.Add("Grade", dbType: DbType.String, value: request.Grade, direction: ParameterDirection.Input);
            _dbParams.Add("Category", dbType: DbType.String, value: request.Category, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpDetailsUpdateResponseDto>("proc_HR_Employee_Details_Update", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpDetailsUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new EmpDetailsUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmpSalaryUpdateBaseResponseDto> EmployeeSalaryUpdate(EmpSalaryUpdateCommand request, CancellationToken ct)
    {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: request.Slug, direction: ParameterDirection.Input);
            _dbParams.Add("BasicSalary", dbType: DbType.Decimal, value: request.BasicSalary, direction: ParameterDirection.Input);
            _dbParams.Add("SalaryGrade", dbType: DbType.String, value: request.SalaryGrade, direction: ParameterDirection.Input);
            _dbParams.Add("PayFrequncy", dbType: DbType.String, value: request.Frequncy, direction: ParameterDirection.Input);
            _dbParams.Add("BankName", dbType: DbType.String, value: request.BankName, direction: ParameterDirection.Input);
            _dbParams.Add("BankAccountNo", dbType: DbType.String, value: request.BankAccountNo, direction: ParameterDirection.Input);
            _dbParams.Add("BankAccountName", dbType: DbType.String, value: request.BankAccountName, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpSalaryUpdateResponseDto>("proc_HR_Employee_Salary_Update", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpSalaryUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new EmpSalaryUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmpStatutoryUpdateBaseResponseDto> EmployeeStatutoryUpdate(EmpStatutoryUpdateCommand request, CancellationToken ct)
    {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: request.Slug, direction: ParameterDirection.Input);
            _dbParams.Add("Tin", dbType: DbType.Decimal, value: request.Tin, direction: ParameterDirection.Input);
            _dbParams.Add("Pfa", dbType: DbType.String, value: request.Pfa, direction: ParameterDirection.Input);
            _dbParams.Add("PensionNo", dbType: DbType.String, value: request.PensionNo, direction: ParameterDirection.Input);
            _dbParams.Add("Nhf", dbType: DbType.String, value: request.Nhf, direction: ParameterDirection.Input);
            _dbParams.Add("Nsitf", dbType: DbType.String, value: request.Nsitf, direction: ParameterDirection.Input);
            _dbParams.Add("Nhis", dbType: DbType.String, value: request.Nhis, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpStatutoryUpdateResponseDto>("proc_HR_Employee_Statutory_Update", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpStatutoryUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new EmpStatutoryUpdateBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmpLoginAccessBaseResponseDto> EmployeeLoginAccess(EmpLoginAccessCommand request, CancellationToken ct)
    {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("Slug", dbType: DbType.String, value: request.Slug, direction: ParameterDirection.Input);
            _dbParams.Add("EmployeeUsername", dbType: DbType.String, value: request.EmployeeUsername, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<EmpLoginAccessResponseDto>("proc_HR_Employee_Login_Access_Update", _dbParams, commandType: CommandType.StoredProcedure));

            return new EmpLoginAccessBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = result
            };
        }
        catch (Exception ex)
        {
            return new EmpLoginAccessBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }
}
