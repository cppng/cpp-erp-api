using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Helper.Configuration.Auth
{
    public class TokenConfig
    {
        public string SecretKey { get; set; } = string.Empty;
        public string TokenType { get; set; } = string.Empty;
        public int TokenExpiration { get; set; }
    }
}
