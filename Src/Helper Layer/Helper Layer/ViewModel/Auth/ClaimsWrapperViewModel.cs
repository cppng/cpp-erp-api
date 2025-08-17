using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.ViewModel.Auth
{
    public class ClaimsWrapperViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string ClientKey { get; set; } = string.Empty;
        public string RegistrationStatus { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
    }
}
