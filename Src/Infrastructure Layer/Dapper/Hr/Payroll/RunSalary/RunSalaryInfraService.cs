using Azure.Core;
using Dapper;
using Erp.Domain.Entities.Hr;
using Erp.Helper.Commands.Hr.Payroll;
using Erp.Helper.Dto.Request.Hr.Employee;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.Hr.Payroll;
using Erp.Helper.Dto.Response.User;
using Erp.Persistence.Context;
using Erp.Persistence.Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Erp.Infrastructure.Dapper.Hr.Payroll.RunSalary;

public class RunSalaryInfraService : IRunSalaryInfraService
{
    private readonly IDapperService _dapperService;
    private DynamicParameters _dbParams;
    private readonly ErpDbContext _context;

    public RunSalaryInfraService(IDapperService dapperService, ErpDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dapperService = dapperService ?? throw new ArgumentNullException(nameof(dapperService));
    }

    public async Task<RunSalaryBaseResponseDto> RunSalary(RunSalaryCommand request, CancellationToken ct)
    {
        try
        {
            List<long> Ids = new List<long>();
            var employees = await GetEmployees();
            foreach (var employee in employees)
            {
                var run = await RunEmployeeSalary(employee.Slug, request.Month);
                if (run != default)
                {
                    Ids.Add(employee.Id);
                }
            }

            return new RunSalaryBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Run sallry successful",
                StatusCode = HttpResponseCode.Success,
                Success = true,
            };

        }
        catch (Exception ex)
        {
            return new RunSalaryBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<RunSalaryResponseDto> RunEmployeeSalary(string employeeSlug, int month)
    {
        try
        {

            _dbParams = new DynamicParameters();

            _dbParams.Add("EmployeeSlug", dbType: DbType.String, value: employeeSlug, direction: ParameterDirection.Input);
            _dbParams.Add("Month", dbType: DbType.Int32, value: month, direction: ParameterDirection.Input);

            var result = await Task.FromResult(_dapperService.Get<RunSalaryResponseDto>("proc_HR_Run_Salary", _dbParams, commandType: CommandType.StoredProcedure));

            return result;
        }
        catch (Exception ex)
        {
            return new RunSalaryResponseDto();
        }
    }

    public async Task<List<EmployeeEntity>> GetEmployees()
    {
        try
        {

            var employees = await _context.EmployeeEntities.ToListAsync();
            return employees;

        }
        catch (Exception ex)
        {
            return new List<EmployeeEntity>();
        }
    }
}
