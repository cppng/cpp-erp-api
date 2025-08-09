using Erp.Helper.ViewModel.Auth;

namespace Erp.Infrastructure.Services.TokenService
{
    public interface ITokenGenerator
    {
        Task<TokenGeneratorViewModel> GenerateToken(TokenUserDetailsViewModel tokenUserDetails);
    }
}