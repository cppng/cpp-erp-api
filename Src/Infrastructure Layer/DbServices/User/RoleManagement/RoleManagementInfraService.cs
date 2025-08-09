using AutoMapper;
using Erp.Domain.Entities.User;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.User;
using Erp.Infrastructure.DbServices.User.RoleManagement;
using Erp.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace Erp.Infrastructure.DbServices.User.Role;

public class RoleManagementInfraService : IRoleManagementInfraService
{
    private readonly ErpDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public RoleManagementInfraService(ErpDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<RoleBaseResponseDto> CreateRole(RoleRequestCommand request, CancellationToken ct)
    {
        try
        {

            if (_roleManager.RoleExistsAsync(request.Name).Result) {
                return new RoleBaseResponseDto
                {
                    ResponseCode = AppResponseCode.InternalError,
                    Message = "Role already exist. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                };
            }

            var role = await _roleManager.CreateAsync(new IdentityRole { 
                Name = request.Name, 
                NormalizedName = request.Name.ToLower(),
                ConcurrencyStamp = DateTime.Now.TimeOfDay.ToString()
            });
            if (!role.Succeeded)
            {
                return new RoleBaseResponseDto
                {
                    ResponseCode = AppResponseCode.UnAuthorized,
                    Message = string.Join(", ", role.Errors.Select(p => p.Description)),
                    StatusCode = HttpResponseCode.UnAuthorized,
                    Success = false,
                };
            }

            return new RoleBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = new RoleResponseDto
                {
                    Username = "",
                    Name = request.Name
                }
            };

        }
        catch (Exception ex) {
            return new RoleBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Failed to create user. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<UserToRoleBaseResponseDto> AddUserToRole(UserToRoleRequestCommand request, CancellationToken ct)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == default)
            {
                return new UserToRoleBaseResponseDto
                {
                    ResponseCode = AppResponseCode.InternalError,
                    Message = $"A user with the username {request.Username} does not exist. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                };
            }

            if (!_roleManager.RoleExistsAsync(request.RoleName).Result)
            {
                return new UserToRoleBaseResponseDto
                {
                    ResponseCode = AppResponseCode.InternalError,
                    Message = $"The Role, {request.RoleName} does not exist. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                };
            }

            var role = await _userManager.AddToRoleAsync(user, request.RoleName);
            if (!role.Succeeded)
            {
                return new UserToRoleBaseResponseDto
                {
                    ResponseCode = AppResponseCode.UnAuthorized,
                    Message = string.Join(", ", role.Errors.Select(p => p.Description)),
                    StatusCode = HttpResponseCode.UnAuthorized,
                    Success = false,
                };
            }

            return new UserToRoleBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = new UserToRoleResponseDto
                {
                    Username = request.Username,
                    RoleName = request.RoleName
                }
            };

        }
        catch (Exception ex)
        {
            return new UserToRoleBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = $"Filed to add user {request.Username} to role {request.RoleName}. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<RoleListingBaseResponseDto> GetRoles(string username, CancellationToken ct)
    {
        try
        {
            var roles = _roleManager.Roles.ToList();
            return new RoleListingBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = roles
            };

        }
        catch (Exception ex)
        {
            return new RoleListingBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }
}
