using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Erp.Helper.ViewModel.Auth;
using Erp.Helper.Configuration.Auth;

namespace Erp.Infrastructure.Services.TokenService;

public class TokenGenerator : ITokenGenerator
{
    private readonly TokenConfig _tokenConfig;
    public TokenGenerator(IOptions<TokenConfig> tokenConfig)
    {
        _tokenConfig = tokenConfig.Value;
    }
    public async Task<TokenGeneratorViewModel> GenerateToken(TokenUserDetailsViewModel tokenUserDetails)
    {

        try
        {
          
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, tokenUserDetails.UserId.ToString()),
                    new Claim(ClaimTypes.Name, tokenUserDetails.Username.ToLower()),
                    new Claim(ClaimTypes.Email, tokenUserDetails.Email),
                    new Claim(ClaimTypes.Role, tokenUserDetails.Role == default ? "Anonymous" : tokenUserDetails.Role),
                    new Claim(nameof(ClaimsWrapperViewModel.Fullname),  tokenUserDetails.Fullname == default ? string.Empty : tokenUserDetails.Fullname),
                    new Claim(nameof(ClaimsWrapperViewModel.PhoneNumber),  tokenUserDetails.PhoneNumber == default ? string.Empty : tokenUserDetails.PhoneNumber),
                    new Claim(nameof(ClaimsWrapperViewModel.RegistrationStatus),  tokenUserDetails.RegistrationStatus == default ? string.Empty : tokenUserDetails.RegistrationStatus),
                    new Claim(nameof(ClaimsWrapperViewModel.Tenant),  tokenUserDetails.Tenant == default ? string.Empty : tokenUserDetails.Tenant),
                    new Claim(nameof(ClaimsWrapperViewModel.UserId),  tokenUserDetails.UserId == default ? string.Empty : tokenUserDetails.UserId.ToString()),
                }),

                Expires = System.DateTime.UtcNow.AddHours(Convert.ToInt32(_tokenConfig.TokenExpiration)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenConfig.SecretKey)), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            return await Task.Run(() =>
            {
                return new TokenGeneratorViewModel
                {
                    success = true,
                    ResponseCode = "00",
                    AccessToken = tokenHandler.WriteToken(token),
                    TokenExpire = $"{Convert.ToString(_tokenConfig.TokenExpiration)}{" hours"}",
                    TokenType = _tokenConfig.TokenType,
                    Role = tokenUserDetails.Role
                };
            });
        }
        catch (Exception ex)
        {
            return await Task.Run(() =>
            {
                return new TokenGeneratorViewModel
                {
                    success = false,
                    ResponseCode = "03"
                };
            });
        }
    }
}
