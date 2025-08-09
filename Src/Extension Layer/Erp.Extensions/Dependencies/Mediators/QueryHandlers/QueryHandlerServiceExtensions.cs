using Erp.Core.User.Login.Handler.Command;
using Erp.Core.User.NewUser.Handler.Command;
using Erp.Core.User.Role.Handler.Command;
using Erp.Core.User.UserListing.Handler.Queries;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.User;
using Microsoft.Extensions.DependencyInjection;
using SimpleSoft.Mediator;

namespace Erp.Extensions.Dependencies.Mediators.QueryHandlers
{
    public static class QueryHandlerServiceExtensions
    {
        public static IServiceCollection AddQueryHandlerApplicationServics(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<UserListingQueryRequest, UserListingBaseResponseDto>, UserListingHandler>();
            services.AddTransient<IQueryHandler<RoleListingQueryRequest, RoleListingBaseResponseDto>, RoleListingHandler>();

            return services;
        }
    }
}
