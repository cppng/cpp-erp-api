using Erp.Domain.Entities.Hr;
using Erp.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Persistence.Context
{
    public class ErpDbContext: IdentityDbContext<ApplicationUser>
    {
        public ErpDbContext(DbContextOptions<ErpDbContext> options) : base(options) 
        { }

        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<EmployeeEntity> EmployeeEntities { get; set; }
        public DbSet<EmpPayElemEntity> EmpPayElemEntities { get; set; }
    }
}
