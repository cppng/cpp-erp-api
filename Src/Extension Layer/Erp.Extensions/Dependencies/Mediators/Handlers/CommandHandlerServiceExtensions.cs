using Erp.Core.User.EmployeeList.Handler.Command;
using Erp.Core.User.Login.Handler.Command;
using Erp.Core.User.NewEmployee.Handler.Command;
using Erp.Core.User.NewUser.Handler.Command;
using Erp.Core.User.Role.Handler.Command;
using Erp.Helper.Commands.Hr.Employee;
using Erp.Helper.Commands.User;
using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using Microsoft.Extensions.DependencyInjection;
using SimpleSoft.Mediator;

namespace Erp.Extensions.Dependencies.Mediators.Handlers
{
    public static class CommandHandlerServiceExtensions
    {
        public static IServiceCollection AddCommandHandlerApplicationServics(this IServiceCollection services)
        {
            services.AddTransient<ICommandHandler<LoginRequestCommand, LoginBaseResponseDto>, LoginCommandHandler>();
            services.AddTransient<ICommandHandler<NewUserRequestCommand, NewUserBaseResponseDto>, NewUserCommandHandler>();
            services.AddTransient<ICommandHandler<RoleRequestCommand, RoleBaseResponseDto>, RoleCommandHandler>();
            services.AddTransient<ICommandHandler<UserToRoleRequestCommand, UserToRoleBaseResponseDto>, UserToRoleCommandHandler>();
            services.AddTransient<ICommandHandler<NewEmployeeCommand, NewEmployeeBaseResponseDto>, NewEmployeeCommandHandler>();
            services.AddTransient<ICommandHandler<EmployeesCommand, EmployeesBaseResponseDto>, EmployeeListCommandHandler>();
            services.AddTransient<ICommandHandler<EmpBasicUpdateCommand, EmpBasicUpdateBaseResponseDto>, EmpBasicUpdateCommandHandler>();
            services.AddTransient<ICommandHandler<EmpContactUpdateCommand, EmpContactUpdateBaseResponseDto>, EmpContactUpdateCommandHandler>();
            services.AddTransient<ICommandHandler<EmpNokUpdateCommand, EmpNokUpdateBaseResponseDto>, EmpNokUpdateCommandHandler>();
            services.AddTransient<ICommandHandler<EmpDetailsUpdateCommand, EmpDetailsUpdateBaseResponseDto>, EmpDetailsUpdateCommandHandler>();
            services.AddTransient<ICommandHandler<EmpSalaryUpdateCommand, EmpSalaryUpdateBaseResponseDto>, EmpSalaryUpdateCommandHandler>();
            services.AddTransient<ICommandHandler<EmpStatutoryUpdateCommand, EmpStatutoryUpdateBaseResponseDto>, EmpStatutoryUpdateCommandHandler>();

            return services;
        }
    }
}
