using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.ViewModel.Auth
{
    public class TokenUserDetailsViewModel
    {
        public string Fullname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string RegistrationStatus { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

    }
}
