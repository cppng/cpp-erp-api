using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response.User
{
    public class UserToRoleResponseDto
    {
        public string Username { get; set; } = string.Empty;
        public string RoleName { get; set; } = string.Empty;
    }

    public class UserToRoleBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public UserToRoleResponseDto data { get; set; } = new UserToRoleResponseDto();
    }
}
