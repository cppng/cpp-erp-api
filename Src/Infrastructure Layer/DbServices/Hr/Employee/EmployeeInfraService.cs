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

    
}
