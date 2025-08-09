using Erp.Helper.Configuration.Auth;
using Erp.Infrastructure.Dapper.Hr.NewEmployee;
using Erp.Infrastructure.DbServices.User.Login;
using Erp.Infrastructure.DbServices.User.NewUser;
using Erp.Infrastructure.DbServices.User.Role;
using Erp.Infrastructure.DbServices.User.RoleManagement;
using Erp.Infrastructure.DbServices.User.UserManagement;
using Erp.Infrastructure.Services.TokenService;
using Erp.Persistence.Dapper;
using Erp.Persistence.Repositories.Interface;
using Erp.Persistence.Repositories.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Extensions.Dependencies.Domain
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services) 
        {
            services.AddScoped<IDapperService, DapperService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
