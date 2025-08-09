using Erp.Helper.Dto.Response.Hr.Employee;
using Erp.Helper.Dto.Response.User;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Commands.Hr.Employee
{
    public class EmpStatutoryUpdateCommand : Command<EmpStatutoryUpdateBaseResponseDto>
    {
        public string Slug { get; set; } = string.Empty;
        public decimal Tin { get; set; }
        public string Pfa { get; set; } = string.Empty;
        public string PensionNo { get; set; } = string.Empty;
        public string Nhf { get; set; } = string.Empty;
        public string Nsitf { get; set; } = string.Empty;
        public string Nhis { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
    }
}
