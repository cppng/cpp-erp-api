using Azure.Core;
using Dapper;
using Erp.Domain.Entities.Hr;
using Erp.Helper.Commands.Hr.Payroll;
using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.Hr.Payroll;
using Erp.Helper.Dto.Response.User;
using Erp.Persistence.Context;
using Erp.Persistence.Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Erp.Infrastructure.Dapper.Hr.Payroll.Salary;

public class SalaryInfraService : ISalaryInfraService
{
    private readonly IDapperService _dapperService;
    private DynamicParameters _dbParams;
    private readonly ErpDbContext _context;

    public SalaryInfraService(IDapperService dapperService, ErpDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dapperService = dapperService ?? throw new ArgumentNullException(nameof(dapperService));
    }

    public async Task<PayslipBaseResponseDto> GetPayslip(PayslipCommand request, CancellationToken ct)
    {
        try
        {
            var employee = await GetEmployeeByUsername(request.Username);

            if (employee == default) {
                return new PayslipBaseResponseDto
                {
                    ResponseCode = AppResponseCode.RecordNotFound,
                    Message = "Failed to get employee data",
                    StatusCode = HttpResponseCode.RecordNotFound,
                    Success = false,
                };
            }

            var empElems = await GetProcessedSalary(employee.Slug, request.Month);

            var data = new PayslipResponseDto
            {
                EmployeeName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}",
                Organization = employee.Organization,
                Department = employee.Department,
                EmployeeId = employee.EmploymentId,
                Grade = employee.Grade,
                PayGrade = employee.SalaryGrade,
                PayElements = empElems
            };


            return new PayslipBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Run sallry successful",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = data
            };

        }
        catch (Exception ex)
        {
            return new PayslipBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<List<ProcessedSalaryResponseDto>> GetProcessedSalary(string employeeSlug, int month)
    {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("EmployeeSlug", dbType: DbType.String, value: employeeSlug, direction: ParameterDirection.Input);
            _dbParams.Add("Month", dbType: DbType.Int32, value: month, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.GetAll<ProcessedSalaryResponseDto>("proc_HR_Processed_Salary_Select", _dbParams, commandType: CommandType.StoredProcedure));

            return result;
        }
        catch (Exception ex)
        {
            return new List<ProcessedSalaryResponseDto>();
        }
    }

    public async Task<EmployeeEntity> GetEmployeeByUsername(string username)
    {
        try
        {

            var employees = await _context.EmployeeEntities.Where(x => x.EmployeeUsername.Trim().ToLower() == username.Trim().ToLower()).FirstOrDefaultAsync();
            return employees;

        }
        catch (Exception ex)
        {
            return new EmployeeEntity();
        }
    }
}
