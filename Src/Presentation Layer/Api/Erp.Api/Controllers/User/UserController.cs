using Erp.Core.User.Login.BusService;
using Erp.Core.User.NewUser.BusService;
using Erp.Core.User.Role.BusService;
using Erp.Core.User.RoleListing.BusService;
using Erp.Core.User.UserListing.BusService;
using Erp.Core.User.UserListing.Handler.Queries;
using Erp.Core.User.UserToRole.BusService;
using Erp.Helper.Dto.Request.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Erp.Api.Controllers.User
{
    [Route("api/user")]
    [ApiController]
    public class UserController : BaseController
    {

        private readonly INewUserCoreService _newUserCoreService;
        private readonly ILoginCoreService _loginCoreService;
        private readonly IUserListingCoreService _userListingCoreService;
        private readonly IRoleCoreService _roleCoreService;
        private readonly IUserToRoleCoreService _userToRoleCoreService;
        private readonly IRoleListingCoreService _roleListingCoreService;

        public UserController(
            INewUserCoreService newUserCoreService, 
            ILoginCoreService loginCoreService,
            IUserListingCoreService userListingCoreService,
            IRoleCoreService roleCoreService,
            IUserToRoleCoreService userToRoleCoreService,
            IRoleListingCoreService roleListingCoreService
        )
        {
            _newUserCoreService = newUserCoreService ?? throw new ArgumentNullException(nameof(newUserCoreService));
            _loginCoreService = loginCoreService ?? throw new ArgumentNullException(nameof(loginCoreService));
            _userListingCoreService = userListingCoreService ?? throw new ArgumentNullException(nameof(userListingCoreService));
            _roleCoreService = roleCoreService ?? throw new ArgumentNullException(nameof(roleCoreService));
            _userToRoleCoreService = userToRoleCoreService ?? throw new ArgumentNullException(nameof(userToRoleCoreService));
            _roleListingCoreService = roleListingCoreService ?? throw new ArgumentNullException(nameof(roleListingCoreService));
        }

        [HttpPost("create-new-user")]
        public async Task<IActionResult> NewUser([FromBody] NewUserRequestDto request, CancellationToken ct) => Response(await _newUserCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request, CancellationToken ct) => Response(await _loginCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpGet("user-list")]
        public async Task<IActionResult> UserListing(CancellationToken ct) => Response(await _userListingCoreService.Execute(ct).ConfigureAwait(false));

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] RoleRequestDto request, CancellationToken ct) => Response(await _roleCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpPost("add-user-to-role")]
        public async Task<IActionResult> UserToRole([FromBody] UserToRoleRequestDto request, CancellationToken ct) => Response(await _userToRoleCoreService.Execute(request, ct).ConfigureAwait(false));

        [HttpGet("role-list")]
        public async Task<IActionResult> RoleListing(CancellationToken ct) => Response(await _roleListingCoreService.Execute(ct).ConfigureAwait(false));
    }
}
