using Erp.Core.User.EmpBasicUpdate.BusService;
using Erp.Core.User.EmpContactUpdate.BusService;
using Erp.Core.User.EmpDetailsUpdate.BusService;
using Erp.Core.User.EmployeeList.BusService;
using Erp.Core.User.EmpNokUpdate.BusService;
using Erp.Core.User.EmpNokUpdate.SaveEmpPayElem;
using Erp.Core.User.EmpSalaryUpdate.BusService;
using Erp.Core.User.EmpStatutoryUpdate.BusService;
using Erp.Core.User.Login.BusService;
using Erp.Core.User.NewEmployee.BusService;
using Erp.Core.User.NewUser.BusService;
using Erp.Core.User.Role.BusService;
using Erp.Core.User.RoleListing.BusService;
using Erp.Core.User.UserListing.BusService;
using Erp.Core.User.UserToRole.BusService;
using Microsoft.Extensions.DependencyInjection;

namespace Erp.Extensions.Dependencies.ApplicationCore
{
    public static class ApplicationCoreServiceExtension
    {
        public static IServiceCollection AddApplicationCoreServices(this IServiceCollection services) 
        {

            //USER
            services.AddScoped<ILoginCoreService, LoginCoreService>();
            services.AddScoped<INewUserCoreService, NewUserCoreService>();
            services.AddScoped<IUserListingCoreService, UserListingCoreService>();
            services.AddScoped<IRoleCoreService, RoleCoreService>();
            services.AddScoped<IUserToRoleCoreService, UserToRoleCoreService>();
            services.AddScoped<IRoleListingCoreService, RoleListingCoreService>();

            //HR
            services.AddScoped<INewEmployeeCoreService, NewEmployeeCoreService>();
            services.AddScoped<IEmployeeListCoreService, EmployeeListCoreService>();
            services.AddScoped<IEmpBasicUpdateCoreService, EmpBasicUpdateCoreService>();
            services.AddScoped<IEmpContactUpdateCoreService, EmpContactUpdateCoreService>();
            services.AddScoped<IEmpNokUpdateCoreService, EmpNokUpdateCoreService>();
            services.AddScoped<IEmpDetailsUpdateCoreService, EmpDetailsUpdateCoreService>();
            services.AddScoped<IEmpSalaryUpdateCoreService, EmpSalaryUpdateCoreService>();
            services.AddScoped<IEmpStatutoryUpdateCoreService, EmpStatutoryUpdateCoreService>();
            services.AddScoped<ISaveEmpPayElemCoreService, SaveEmpPayElemCoreService>();

            return services;
        }
    }
}
