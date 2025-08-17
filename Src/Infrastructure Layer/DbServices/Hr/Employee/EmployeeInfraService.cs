using AutoMapper;
using Erp.Domain.Entities.User;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using Erp.Infrastructure.DbServices.User.RoleManagement;
using Erp.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Erp.Infrastructure.DbServices.Hr.Employee;

public class EmployeeInfraService : IEmployeeInfraService
{
    private readonly ErpDbContext _context;
    private readonly IMapper _mapper;

    public EmployeeInfraService(ErpDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<EmployeesBaseResponseDto> GetEmployees(EmployeesCommand request, CancellationToken ct)
    {
        try
        {

            var employees = await _context.EmployeeEntities.ToListAsync();

            return new EmployeesBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = employees
            };

        }
        catch (Exception ex) {
            return new EmployeesBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Failed to create user. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmployeeDetailsBaseResponseDto> GetEmployeeBySlug(string slug, string username, CancellationToken ct)
    {
        try
        {

            var employee = await _context.EmployeeEntities.Where(x=>x.Slug == slug).FirstOrDefaultAsync();

            if (employee == default) {
                return new EmployeeDetailsBaseResponseDto
                {
                    ResponseCode = AppResponseCode.RecordNotFound,
                    Message = "Could not get employee record.",
                    StatusCode = HttpResponseCode.RecordNotFound,
                    Success = false,
                };
            }

            return new EmployeeDetailsBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = employee
            };

        }
        catch (Exception ex)
        {
            return new EmployeeDetailsBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Failed to create user. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmployeeDetailsBaseResponseDto> GetEmployeeByUsername(string username, CancellationToken ct)
    {
        try
        {

            var employee = await _context.EmployeeEntities.Where(x => x.EmployeeUsername == username).FirstOrDefaultAsync();

            if (employee == default)
            {
                return new EmployeeDetailsBaseResponseDto
                {
                    ResponseCode = AppResponseCode.RecordNotFound,
                    Message = "Could not get employee record.",
                    StatusCode = HttpResponseCode.RecordNotFound,
                    Success = false,
                };
            }

            return new EmployeeDetailsBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = employee
            };

        }
        catch (Exception ex)
        {
            return new EmployeeDetailsBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Failed to create user. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<EmpPayElemListBaseResponseDto> GetEmpPayElemList(EmpPayElemListCommand request, CancellationToken ct)
    {
        try
        {

            var elems = await _context.EmpPayElemEntities.Where(x=>x.EmployeeSlug == request.Slug).ToListAsync();

            return new EmpPayElemListBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = elems
            };

        }
        catch (Exception ex)
        {
            return new EmpPayElemListBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Failed to create user. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

}
