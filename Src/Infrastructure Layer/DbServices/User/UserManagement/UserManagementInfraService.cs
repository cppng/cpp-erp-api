using AutoMapper;
using Azure.Core;
using Erp.Domain.Entities.User;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.User;
using Erp.Infrastructure.DbServices.User.UserManagement;
using Erp.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace Erp.Infrastructure.DbServices.User.NewUser;

public class UserManagementInfraService : IUserManagementInfraService
{
    private readonly ErpDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;

    public UserManagementInfraService(ErpDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<NewUserBaseResponseDto> NewUser(NewUserRequestCommand request, CancellationToken ct)
    {
        try
        {

            var userExist = await _userManager.FindByNameAsync(request.Username);
            if(userExist != default)
            {
                return new NewUserBaseResponseDto
                {
                    ResponseCode = AppResponseCode.InternalError,
                    Message = $"A user with the username {request.Username} alredy exist. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                };
            }

            var user = _mapper.Map<NewUserRequestCommand, ApplicationUser>(request);
            user.UserId = Guid.NewGuid();
            user.UserName = request.Username;

            var createUser = await _userManager.CreateAsync(user, request.Password);
            if (!createUser.Succeeded)
            {
                return new NewUserBaseResponseDto
                {
                    ResponseCode = AppResponseCode.UnAuthorized,
                    Message = string.Join(", ", createUser.Errors.Select(p => p.Description)),
                    StatusCode = HttpResponseCode.UnAuthorized,
                    Success = false,
                };
            }

            return new NewUserBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = new NewUserResponseDto
                {
                    UserId = user.Id,
                    Title = user.FirstName,
                    FirstName = user.Title,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                    FullName = $"{user.FirstName} {user.MiddleName} {user.LastName}",
                    Username = user.UserName,
                }
            };

        }
        catch (Exception ex) {
            return new NewUserBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

    public async Task<UserListingBaseResponseDto> GetUsers(string username, CancellationToken ct)
    {
        try
        {
            var appUsers = _userManager.Users.ToList();
            var users = _mapper.Map<List<ApplicationUser>, List<UserResponseDto>>(appUsers);

            return new UserListingBaseResponseDto
            {
                ResponseCode = AppResponseCode.Success,
                Message = "Success",
                StatusCode = HttpResponseCode.Success,
                Success = true,
                data = users
            };

        }
        catch (Exception ex)
        {
            return new UserListingBaseResponseDto
            {
                ResponseCode = AppResponseCode.InternalError,
                Message = "Login was not successful. Please try again",
                StatusCode = HttpResponseCode.InternalError,
                Success = false,
            };
        }
    }

}
