using Erp.Helper.Configuration.Auth;
using Erp.Infrastructure.Dapper.Hr.Employee.EmployeeUpdate;
using Erp.Infrastructure.Dapper.Hr.Employee.EmpPayElement;
using Erp.Infrastructure.Dapper.Hr.Employee.NewEmployee;
using Erp.Infrastructure.Dapper.Hr.Payroll.RunSalary;
using Erp.Infrastructure.Dapper.Hr.Payroll.Salary;
using Erp.Infrastructure.DbServices.Hr.Employee;
using Erp.Infrastructure.DbServices.User.Login;
using Erp.Infrastructure.DbServices.User.NewUser;
using Erp.Infrastructure.DbServices.User.Role;
using Erp.Infrastructure.DbServices.User.RoleManagement;
using Erp.Infrastructure.DbServices.User.UserManagement;
using Erp.Infrastructure.Services.TokenService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Extensions.Dependencies.Infrastructure
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastureServices(this IServiceCollection services) 
        {
            services.AddScoped<ILoginInfraService, LoginInfraService>();
            services.AddScoped<IUserManagementInfraService, UserManagementInfraService>();
            services.AddScoped<IRoleManagementInfraService, RoleManagementInfraService>();
            services.AddScoped<INewEmployeeInfraService, NewEmployeeInfraService>();
            services.AddScoped<IEmployeeInfraService, EmployeeInfraService>();
            services.AddScoped<IEmployeeUpdateInfraService, EmployeeUpdateInfraService>();
            services.AddScoped<IEmpPayElemInfraService, EmpPayElemInfraService>();
            services.AddScoped<IRunSalaryInfraService, RunSalaryInfraService>();
            services.AddScoped<ISalaryInfraService, SalaryInfraService>();

            var appSettingsConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();

            services.Configure<TokenConfig>(appSettingsConfig.GetSection(nameof(TokenConfig)));

            services.AddScoped<ITokenGenerator, TokenGenerator>();

            return services;
        }
    }
}
