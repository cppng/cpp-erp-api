using Erp.Helper.Dto.Request.User;
using Erp.Helper.Dto.Response.User;

namespace Erp.Core.User.Login.BusService
{
    public interface ILoginCoreService
    {
        Task<LoginBaseResponseDto> Execute(LoginRequestDto request, CancellationToken ct);
    }
}
