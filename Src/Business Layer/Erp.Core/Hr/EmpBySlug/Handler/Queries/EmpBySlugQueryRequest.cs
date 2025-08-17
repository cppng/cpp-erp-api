using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Core.Hr.EmpBySlug.Handler.Queries
{
    public class EmpBySlugQueryRequest: Query<EmployeeDetailsBaseResponseDto>
    {
        public string Slug { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}
