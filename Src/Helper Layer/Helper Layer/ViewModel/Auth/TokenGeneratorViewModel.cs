using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.ViewModel.Auth
{
    public class TokenGeneratorViewModel
    {
        public string ResponseCode { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public string TokenType { get; set; } = string.Empty;
        public string TokenExpire { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string RegistrationStatus { get; set; } = string.Empty;
        public string Tenant { get; set; } = string.Empty;
        public bool success { get; set; }
    }
}
