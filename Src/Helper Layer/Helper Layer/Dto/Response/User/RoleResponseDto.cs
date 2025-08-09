using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Erp.Helper.Dto.Response.User
{
    public class RoleResponseDto
    {
        public string Username { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class RoleBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public RoleResponseDto data { get; set; } = new RoleResponseDto();
    }

    public class RoleListingBaseResponseDto
    {
        public string ResponseCode { get; set; } = string.Empty;
        public bool Success { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<IdentityRole> data { get; set; } = new List<IdentityRole>();
    }
}
