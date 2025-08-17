using AutoMapper;
using Erp.Domain.Entities.User;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response;
using Erp.Helper.Dto.Response.User;
using Erp.Helper.ViewModel.Auth;
using Erp.Infrastructure.Services.TokenService;
using Erp.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Infrastructure.DbServices.User.Login
{
    public class LoginInfraService: ILoginInfraService
    {
        private readonly ErpDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ITokenGenerator _tokenGenerator;

        public LoginInfraService(ErpDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, IMapper mapper, ITokenGenerator tokenGenerator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _tokenGenerator = tokenGenerator ?? throw new ArgumentNullException(nameof(tokenGenerator));
        }

        public async Task<LoginBaseResponseDto> AuthenticateUser(LoginRequestCommand request, CancellationToken ct)
        {
            try
            {

                var user = await _userManager.FindByNameAsync(request.ClientId);
                if (user == default) {
                    return new LoginBaseResponseDto
                    {
                        ResponseCode = AppResponseCode.RecordNotFound,
                        Message = "Invalid username or password",
                        StatusCode = HttpResponseCode.RecordNotFound,
                        Success = false,
                    };
                }

                var validateUser = await _userManager.CheckPasswordAsync(user, request.ClientSecrete);
                if (!validateUser) {
                    return new LoginBaseResponseDto
                    {
                        ResponseCode = AppResponseCode.RecordNotFound,
                        Message = "Invalid username or password",
                        StatusCode = HttpResponseCode.RecordNotFound,
                        Success = false,
                    };
                }

                var token = await _tokenGenerator.GenerateToken(new TokenUserDetailsViewModel
                {
                    RegistrationStatus = "",
                    Name = user.Name,
                    Role = "",
                    UserId = user.UserId.ToString(),
                    Username = user.UserName,
                    Tenant = ""
                });

                if (!token.success)
                {
                    return new LoginBaseResponseDto
                    {
                        ResponseCode = AppResponseCode.RecordNotFound,
                        Message = "Invalid username or password",
                        StatusCode = HttpResponseCode.RecordNotFound,
                        Success = false,
                    };
                }

                return new LoginBaseResponseDto
                {
                    ResponseCode = AppResponseCode.Success,
                    Message = "Success",
                    StatusCode = HttpResponseCode.Success,
                    Success = true,
                    data = new LoginResponseDto
                    {
                        Name = user.Name,
                        Username = user.UserName,
                        AccessToken = token.AccessToken                    
                    }
                };
            }
            catch (Exception ex) {
                return new LoginBaseResponseDto
                {
                    ResponseCode = AppResponseCode.InternalError,
                    Message = "Login was not successful. Please try again",
                    StatusCode = HttpResponseCode.InternalError,
                    Success = false,
                };
            }
        }
    }
}
